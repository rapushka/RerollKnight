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

		private float WholeDuration => _viewConfig.RerollDuration;

		private float MaxHeight => _viewConfig.RerollThrowHeight;

		public void Execute()
		{
			foreach (var timer in _timers)
			foreach (var actor in _actors)
			{
				var currentHeight = timer.Get<SpentTime>().Value.Sin(WholeDuration) * MaxHeight;
				actor.Replace<Position, Vector3>(actor.Get<Position>().Value.Set(y: currentHeight));
			}
		}
	}
}