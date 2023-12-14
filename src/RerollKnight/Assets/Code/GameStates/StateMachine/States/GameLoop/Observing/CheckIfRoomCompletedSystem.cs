using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class CheckIfRoomCompletedSystem : IInitializeSystem, IStateTransferSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<GameScope>> _enemies;

		public CheckIfRoomCompletedSystem(Contexts contexts)
		{
			_enemies = contexts.GetGroup(AllOf(Get<Enemy>()));
		}

		public StateMachineBase StateMachine { get; set; }

		private bool HasEnemiesInCurrentRoom => _enemies.Any(IsInCurrentRoom);

		public void Initialize()
		{
			if (!HasEnemiesInCurrentRoom)
				StateMachine.ToState<WanderingGameplayState>();
		}

		private bool IsInCurrentRoom(Entity<GameScope> entity)
			=> entity.GetOwner().Is<Room>() && !entity.GetOwner().Is<Disabled>();
	}
}