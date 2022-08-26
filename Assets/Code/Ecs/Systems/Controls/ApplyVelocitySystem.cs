using Code.Workflow.Extensions;
using Entitas;

namespace Code.Ecs.Systems.Controls
{
	public sealed class ApplyVelocitySystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public ApplyVelocitySystem(Contexts contexts)
		{
			_entities = contexts.game.GetAllOf(GameMatcher.CharacterController, GameMatcher.Velocity);
		}

		public void Execute() => _entities.ForEach(Move);

		private static void Move(GameEntity e)
			=> e.characterController.Value.Move(e.velocity);
	}
}