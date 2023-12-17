using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class OutlineHoveredTargetsSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;

		[Inject]
		public OutlineHoveredTargetsSystem(Contexts contexts)
			=> _targets = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Target>());

		public void Execute()
		{
			foreach (var e in _targets)
			{
				e.Is<EnableOutline>(e.Is<Hovered>());
				e.Replace<Component.TargetState, TargetState>(TargetState.Hovered);
			}
		}
	}
}