using Code.Workflow.Extensions;
using Entitas;

namespace Code.Ecs.Systems.View.Initialization
{
	public sealed class MoveViewToSpawnPositionSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public MoveViewToSpawnPositionSystem(Contexts contexts)
		{
			_entities = contexts.game.GetAllOf
			(
				GameMatcher.SpawnPosition,
				GameMatcher.Transform
			);
		}

		public void Execute() => _entities.ForEach(Move);

		private static void Move(GameEntity e)
		{
			e.transform.Value.position = e.spawnPosition;
		}
	}
}