using System.Collections.Generic;
using Code.Unity.Services.Interfaces;
using Entitas;

namespace Code.Ecs.Systems.ReactiveSystems
{
	public sealed class LoadViewSystem : ReactiveSystem<GameEntity>
	{
		private readonly ServicesContext _services;

		public LoadViewSystem(Contexts contexts) : base(contexts.game)
		{
			_services = contexts.services;
		}

		private IViewsService ViewsService => _services.viewService.Value;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.ViewToLoad);

		protected override bool Filter(GameEntity entity)
			=> entity.hasViewController == false;

		protected override void Execute(List<GameEntity> entities)
			=> entities.ForEach(LoadView);

		private void LoadView(GameEntity entity)
			=> ViewsService.LoadViewForEntity(entity.viewToLoad.Value, entity);
	}
}
