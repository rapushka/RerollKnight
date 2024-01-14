using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class MoveChipToSideWindow : PickSideWindow
	{
		[SerializeField] private ChipButton _chipButtonPrefab;
		[SerializeField] private Transform _chipsRoot;

		private Entity<GameScope> _pickedChip;

		private readonly List<ChipButton> _chipButtons = new();

		public override void SetData(Entity<GameScope> senderChip, Entity<GameScope> actor)
		{
			base.SetData(senderChip, actor);

			var activeSide = actor.GetActiveFace();

			foreach (var chip in activeSide.GetDependants().WhereHas<Chip>())
			{
				var chipButton = Instantiate(_chipButtonPrefab, _chipsRoot);
				chipButton.SetData(chip);
				chipButton.Clicked += OnChipPicked;
				_chipButtons.Add(chipButton);
			}
		}

		protected override void OnHide()
		{
			base.OnHide();

			DestroyChipButtons();

			_pickedChip = null;
			PickedSide = null;
		}

		protected override void OnSidePicked(Entity<GameScope> side)
		{
			base.OnSidePicked(side);

			UpdateConfirmAvailability();
		}

		private void OnChipPicked(Entity<GameScope> chip)
		{
			_pickedChip = chip;

			foreach (var button in _chipButtons)
				button.IsSelected = button.Chip == _pickedChip;

			UpdateConfirmAvailability();
		}

		private void DestroyChipButtons()
		{
			foreach (var chipButton in _chipButtons)
			{
				chipButton.Clicked -= OnChipPicked;
				Destroy(chipButton.gameObject);
			}

			_chipButtons.Clear();
		}

		protected override void OnConfirm()
		{
			if (_pickedChip is null || PickedSide is null)
				return;

			_pickedChip.Replace<ForeignID, string>(PickedSide.EnsureID());
			_pickedChip.Is<AvailableToPick>(false);
			_pickedChip.Is<Visible>(false);

			Hide();
		}

		private void UpdateConfirmAvailability()
			=> IsConfirmAvailable = PickedSide is not null && _pickedChip is not null;
	}
}