using System;
using Entitas.Generic;

namespace Code
{
	public class SideButton : ButtonBase
	{
		public new event Action<Entity<GameScope>> Clicked;

		public Entity<GameScope> Side { get; private set; }

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

		public void SetData(Entity<GameScope> side)
		{
			Side = side;
			Text = Side.ToString();
		}

		private void InvokeClicked() => Clicked?.Invoke(Side);
	}
}