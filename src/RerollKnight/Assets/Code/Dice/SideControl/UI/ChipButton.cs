using System;
using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class ChipButton : ButtonBase
	{
		public new event Action<Entity<GameScope>> Clicked;

		public Entity<GameScope> Chip { get; private set; }

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
			Chip = chip;
			Text = Chip.Get<Label>().Value;
		}

		private void InvokeClicked() => Clicked?.Invoke(Chip);
	}
}