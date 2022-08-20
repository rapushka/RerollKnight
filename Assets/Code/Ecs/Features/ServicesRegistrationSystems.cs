using System;
using Code.Ecs.Systems.InitializeSystems;
using Code.Unity.Services;

namespace Code.Ecs.Features
{
	public sealed class ServicesRegistrationSystems : Feature
	{
		public ServicesRegistrationSystems(Contexts contexts, ServicesCollection services) 
			: base(nameof(ServicesRegistrationSystems))
		{
			GameContext game = contexts.game;
			
			Register(services.Time, game.ReplaceTimeService);
			Register(services.Balance, game.ReplaceBalanceService);
			Register(services.Resources, game.ReplaceResourcesService);
			Register(services.Views, game.ReplaceViewService);
		}

		private void Register<T>(T service, Action<T> replaceService)
			=> Add(new RegisterServiceSystem<T>(service, replaceService));
	}
}
