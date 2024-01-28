using Code.Component;
using Entitas.Generic;

namespace Code
{
	// TODO: remove
	public class VisibleView : BaseListener<GameScope, Visible>
	{
		public override void OnValueChanged(Entity<GameScope> entity, Visible component) { }
	}
}