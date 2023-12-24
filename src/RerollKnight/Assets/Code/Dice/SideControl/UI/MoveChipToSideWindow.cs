using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public class MoveChipToSideWindow : PickSideWindow
	{
		[SerializeField] private ChipButton _chipButtonPrefab;
		[SerializeField] private Transform _chipsRoot;
		[SerializeField] private Button _confirmButton;

		private Entity<GameScope> _pickedSide;
		private Entity<GameScope> _pickedChip;

		private readonly List<ChipButton> _chipButtons = new();

		protected override void OnShow()
		{
			base.OnShow();
			_confirmButton.onClick.AddListener(OnConfirmClicked);
		}

		protected override void OnHide()
		{
			base.OnHide();
			_confirmButton.onClick.RemoveListener(OnConfirmClicked);

			foreach (var chipButton in _chipButtons)
			{
				chipButton.Clicked -= OnChipPicked;
				Destroy(chipButton.gameObject);
			}

			_chipButtons.Clear();
		}

		public override void SetData(Entity<GameScope> actor)
		{
			base.SetData(actor);

			var activeSide = actor.GetActiveFace();

			foreach (var chip in activeSide.GetDependants().WhereHas<Chip>())
			{
				var chipButton = Instantiate(_chipButtonPrefab, _chipsRoot);
				chipButton.SetData(chip);
				chipButton.Clicked += OnChipPicked;
				_chipButtons.Add(chipButton);
			}
		}

		private void OnChipPicked(Entity<GameScope> chip)
		{
			_pickedChip = chip;

			foreach (var button in _chipButtons)
				button.IsSelected = button.Chip == _pickedChip;
		}

		protected override void OnSidePicked(int sideNumber)
		{
			_pickedSide = Actor.GetFace(sideNumber);

			foreach (var button in SideButtons)
				button.IsSelected = button.SideNumber == sideNumber;
		}

		private void OnConfirmClicked()
		{
			if (_pickedChip is null || _pickedSide is null)
				return;

			_pickedChip.Replace<ForeignID, string>(_pickedSide.EnsureID());
			_pickedChip.Is<AvailableToPick>(false);
			_pickedChip.Is<Visible>(false);

			Hide();
		}
	}
}