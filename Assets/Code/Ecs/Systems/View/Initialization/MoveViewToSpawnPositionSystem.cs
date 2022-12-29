using Code.Workflow.Extensions;
using Entitas;
using static GameMatcher;

namespace Code.Ecs.Systems.View.Initialization
{
	public sealed class MoveViewToSpawnPositionSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public MoveViewToSpawnPositionSystem(Contexts contexts)
			=> _entities = contexts.game.GetGroup(AllOf(SpawnPosition, Transform));

		public void Execute() => _entities.ForEach(Move);

		private static void Move(GameEntity e) => e.transform.Value.position = e.spawnPosition;
	}
}