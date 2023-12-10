using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class ThrowDicesSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _actors;
		private readonly IViewConfig _viewConfig;
		private readonly IGroup<Entity<InfrastructureScope>> _timers;

		[Inject]
		public ThrowDicesSystem(Contexts contexts, IViewConfig viewConfig)
		{
			_viewConfig = viewConfig;
			_actors = contexts.GetGroup(Get<Actor>());
			_timers = contexts.GetGroup(ScopeMatcher<InfrastructureScope>.Get<SpentTime>());
		}

		public void Execute()
		{
			foreach (var timer in _timers)
			{
				foreach (var actor in _actors)
				{
					var wholeDuration = _viewConfig.RerollDuration;
					var spentDuration = timer.Get<SpentTime>().Value;
					var maxHeight = _viewConfig.RerollThrowHeight;

					var position = actor.Get<Position>().Value;

					var currentHeight = Mathf.Sin(spentDuration / wholeDuration * Mathf.PI) * maxHeight;
					position.y = currentHeight;
					actor.Replace<Position, Vector3>(position);
				}
			}
		}
	}
}