using System;
using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class ChipButton : ButtonBase
	{
		public new event Action<Entity<GameScope>> Clicked;

		private Entity<GameScope> _chip;

		protected override void OnEnable()
		{
			base.OnEnable();
			base.Clicked += InvokeClicked;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			base.Clicked -= InvokeClicked;
		}

		public void SetData(Entity<GameScope> chip)
		{
			_chip = chip;
			Text = _chip.Get<Label>().ToString();
		}

		private void InvokeClicked() => Clicked?.Invoke(_chip);
	}
}