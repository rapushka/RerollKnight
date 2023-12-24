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

		private Entity<GameScope> _actor;
		private Entity<GameScope> _pickedSide;
		private Entity<GameScope> _pickedChip;

		protected override void OnShow()
		{
			base.OnShow();
			_confirmButton.onClick.AddListener(OnConfirmClicked);
		}

		protected override void OnHide()
		{
			base.OnHide();
			_confirmButton.onClick.RemoveListener(OnConfirmClicked);
		}

		public override void SetData(Entity<GameScope> actor)
		{
			base.SetData(actor);

			var activeSide = actor.GetActiveFace();

			foreach (var chip in activeSide.GetDependants().WhereHas<Chip>())
			{
				var sideButton = Instantiate(_chipButtonPrefab, _chipsRoot);
				sideButton.SetData(chip);
				sideButton.Clicked += OnChipPicked;
			}
		}

		private void OnChipPicked(Entity<GameScope> chip)
		{
			_pickedChip = chip;
		}

		protected override void OnSidePicked(int sideNumber)
		{
			_pickedSide = _actor.GetFace(sideNumber);
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