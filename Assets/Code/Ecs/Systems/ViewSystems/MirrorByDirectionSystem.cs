using System;
using Code.Unity.Views.ViewController;
using Entitas;

namespace Code.Ecs.Systems.ViewSystems
{
	public sealed class MirrorByDirectionSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _entities;

		public MirrorByDirectionSystem(Contexts contexts)
		{
			_entities = contexts.game.GetGroup
			(
				GameMatcher.AllOf
				(
					GameMatcher.Rigidbody,
					GameMatcher.ViewController
				)
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

	public static class CommonExtensions
	{
		public static T Do<T>(this T @this, Action<T> action, bool @if)
		{
			if (@if)
			{
				action.Invoke(@this);
			}

			return @this;
		}
	}
}
