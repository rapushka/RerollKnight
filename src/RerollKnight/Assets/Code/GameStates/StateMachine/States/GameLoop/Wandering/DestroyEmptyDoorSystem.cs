using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public class DestroyEmptyDoorSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _doors;
		private readonly GameplayStateMachine _stateMachine;

		public DestroyEmptyDoorSystem(Contexts contexts, GameplayStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
			_doors = contexts.GetGroup(ScopeMatcher<GameScope>.Get<DoorTo>());
		}

		public void Execute()
		{
			if (_stateMachine.CurrentState is WanderingGameplayState)
				return;

			foreach (var door in _doors)
			{
				if (door.IsEmpty())
					door.Is<Destroyed>(true);
			}
		}
	}
}