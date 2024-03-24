using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class MoveToNextCellInPathSystem : IExecuteSystem
	{
		private readonly IViewConfig _viewConfig;
		private readonly IGroup<Entity<GameScope>> _notDirectedEntities;

		public MoveToNextCellInPathSystem(Contexts contexts, IViewConfig viewConfig)
		{
			_viewConfig = viewConfig;
			_notDirectedEntities = contexts.GetGroup(AllOf(Get<Path>()).NoneOf(Get<DestinationPosition>()));
		}

		public void Execute()
		{
			foreach (var e in _notDirectedEntities.GetEntities())
			{
				var path = e.Get<Path>().Value;
				var nextCoordinates = path.Dequeue();

				var position = nextCoordinates.ToTopDown();

				if (nextCoordinates.OnLayer is Coordinates.Layer.Default)
					position += _viewConfig.OverFieldOffset;

				e.Add<DestinationPosition, Vector3>(position);
				e.Replace<MovingSpeed, float>(_viewConfig.DiceWalkingSpeed);

				if (!path.Any())
					Finish(e);
			}
		}

		private static void Finish(Entity<GameScope> e)
		{
			e.Remove<Path>();

			if (e.Has<ListenerComponent<GameScope, PlayAnimation>>())
			{
				var listeners = e.Get<ListenerComponent<GameScope, PlayAnimation>>().Value;

				foreach (var animatorView in listeners.Cast<AnimatorView>())
					animatorView.OnAnimationEnd();
			}
		}
	}
}