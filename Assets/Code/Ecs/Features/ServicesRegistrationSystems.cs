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
			ServicesContext servicesContext = contexts.services;
			
			Register(services.Time, servicesContext.ReplaceTimeService);
			Register(services.Balance, servicesContext.ReplaceBalanceService);
			Register(services.Resources, servicesContext.ReplaceResourcesService);
			Register(services.Views, servicesContext.ReplaceViewService);
		}

		private void Register<T>(T service, Action<T> replaceService)
			=> Add(new RegisterServiceSystem<T>(service, replaceService));
	}
}
