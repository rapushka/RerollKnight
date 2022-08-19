using Code.Ecs.Systems.InitializeSystems;
using Code.Unity.Services;
using Code.Unity.Services.Interfaces;

namespace Code.Ecs.Features
{
	public sealed class ServicesRegistrationSystems : Feature
	{
		public ServicesRegistrationSystems(Contexts contexts, ServicesCollection services) 
			: base(nameof(ServicesRegistrationSystems))
		{
			GameContext game = contexts.game;
			
			Add(new RegisterServiceSystem<ITimeService>(services.Time, game.ReplaceTimeService));
			Add(new RegisterServiceSystem<IBalanceService>(services.Balance, game.ReplaceBalanceService));
		}
	}
}
