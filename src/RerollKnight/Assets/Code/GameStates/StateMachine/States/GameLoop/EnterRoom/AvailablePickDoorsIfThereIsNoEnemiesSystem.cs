using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class AvailablePickDoorsIfThereIsNoEnemiesSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<GameScope>> _enemies;
		private readonly IGroup<Entity<GameScope>> _doors;

		public AvailablePickDoorsIfThereIsNoEnemiesSystem(Contexts contexts)
		{
			_enemies = contexts.GetGroup(AllOf(Get<Enemy>()));
			_doors = contexts.GetGroup(AllOf(Get<DoorTo>()));
		}

		private bool HasEnemiesInCurrentRoom => _enemies.Any(IsInCurrentRoom);

		public void Initialize()
		{
			if (HasEnemiesInCurrentRoom)
				return;

			foreach (var door in _doors)
				door.Is<AvailableToPick>(true);
		}

		private bool IsInCurrentRoom(Entity<GameScope> entity)
			=> entity.GetOwner().Is<Room>() && !entity.GetOwner().Is<Disabled>();
	}
}