using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public class PickSideWindow : WindowBase, IUninterruptedWindow
	{
		[SerializeField] private SideButton _sideButtonPrefab;
		[SerializeField] private Transform _sidesRoot;
		[SerializeField] private Button _confirmButton;
		[SerializeField] private Button _cancelButton;

		protected readonly List<SideButton> SideButtons = new();
		protected Entity<GameScope> Actor;
		protected Entity<GameScope> PickedSide;

		private Entity<GameScope> _senderChip;
		private bool _confirmed;

		protected bool IsConfirmAvailable { set => _confirmButton.enabled = value; }

		public virtual void SetData(Entity<GameScope> senderChip, Entity<GameScope> actor)
		{
			_senderChip = senderChip;
			Actor = actor;

			foreach (var face in actor.GetDependants().WhereHas<Face>())
			{
				var sideButton = Instantiate(_sideButtonPrefab, _sidesRoot);
				sideButton.SetData(face);
				sideButton.Clicked += OnSidePicked;
				SideButtons.Add(sideButton);
			}
		}

		protected override void OnShow()
		{
			_confirmed = false;
			PickedSide = null;

			_confirmButton.onClick.AddListener(OnConfirmClicked);
			_cancelButton.onClick.AddListener(OnCancelClicked);

			IsConfirmAvailable = false;
		}

		protected override void OnHide()
		{
			DestroySideButtons();

			_confirmButton.onClick.RemoveListener(OnConfirmClicked);
			_cancelButton.onClick.RemoveListener(OnCancelClicked);

			if (_confirmed)
				OnConfirm();
			else
				UndoChipCast();
		}

		private void OnConfirmClicked()
		{
			_confirmed = true;
			Hide();
		}

		private void OnCancelClicked() => Hide();

		private void DestroySideButtons()
		{
			foreach (var sideButton in SideButtons)
			{
				sideButton.Clicked -= OnSidePicked;
				Destroy(sideButton.gameObject);
			}

			SideButtons.Clear();
		}

		protected virtual void OnSidePicked(Entity<GameScope> side)
		{
			IsConfirmAvailable = true;
			PickedSide = side;

			foreach (var button in SideButtons)
				button.IsSelected = button.Side == PickedSide;
		}

		protected virtual void OnConfirm()
		{
			Actor.Replace<PredefinedNextSide, int>(PickedSide.Get<Face>().Value);
		}

		private void UndoChipCast()
		{
			_senderChip?.Is<AvailableToPick>();
		}
	}
}