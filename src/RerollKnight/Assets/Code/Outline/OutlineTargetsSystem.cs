using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class OutlineTargetsSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;

		[Inject]
		public OutlineTargetsSystem(Contexts contexts)
			=> _targets = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Target>());

		public void Execute()
		{
			foreach (var e in _targets)
			{
				var isHovered = e.Is<Hovered>();
				var isAvailable = e.Is<AvailableToPick>();

				e.Is<EnableOutline>(isAvailable || isHovered);

				var targetState
					= isAvailable ? TargetState.Available
					: isHovered   ? TargetState.Hovered
					                : TargetState.Unavailable;

				e.Replace<Component.TargetState, TargetState>(targetState);
			}
		}
	}
}