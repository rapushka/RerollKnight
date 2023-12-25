using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class HealthChangeViewFactory
	{
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly IViewConfig _viewConfig;

		public HealthChangeViewFactory(IAssetsService assets, IResourcesService resources, IViewConfig viewConfig)
		{
			_assets = assets;
			_resources = resources;
			_viewConfig = viewConfig;
		}

		public Entity<GameScope> Create(int delta, Entity<GameScope> target)
		{
			// TODO: mb try ViewTransform
			var targetPosition = target.Get<Position>().Value;

			return _assets.SpawnBehaviour(_resources.HealthChangeViewPrefab).Entity
			              .Add<Position, Vector3>(targetPosition)
			              .Add<HealthChanged, int>(delta)
			              .Add<DestinationPosition, Vector3>(targetPosition + _viewConfig.HealthChangeViewFlyDirection)
			              .Add<MovingSpeed, float>(_viewConfig.HealthChangeViewFlySpeed)
			              .Is<DestroyAfterReachingDestination>(true)
				;
		}
	}
}