using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class OutlineAvailableTargetsSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _targets;

		[Inject]
		public OutlineAvailableTargetsSystem(Contexts contexts)
			=> _targets = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Target>());

		public void Execute()
		{
			foreach (var e in _targets)
			{
				e.Is<EnableOutline>(e.Is<AvailableToPick>());
				e.Replace<TargetStateComponent, TargetState>(TargetState.Available);
			}
		}
	}
}