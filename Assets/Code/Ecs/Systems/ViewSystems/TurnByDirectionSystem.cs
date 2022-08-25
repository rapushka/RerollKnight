using Code.Unity.Views.ViewController;
using Code.Workflow.Extensions;
using Entitas;

namespace Code.Ecs.Systems.ViewSystems
{
	public sealed class TurnByDirectionSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public TurnByDirectionSystem(Contexts contexts)
		{
			_entities = contexts.game.GetAllOf
			(
				GameMatcher.Rigidbody, 
				GameMatcher.ViewController
			);
		}

		public void Execute()
		{
			foreach (GameEntity e in _entities)
			{
				e.Do((x) => ViewController(x).UnMirror(), @if: VelocityX(e) > 0f)
				 .Do((x) => ViewController(x).Mirror(), @if: VelocityX(e) < 0f);
			}
		}

		private static IViewController ViewController(GameEntity x)
			=> x.viewController.Value;

		private static float VelocityX(GameEntity e)
			=> e.rigidbody.Value.velocity.x;
	}
}
