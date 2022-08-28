using Code.Services;

namespace Code.Ecs.Features.CommonSystems
{
	public sealed class CommonSystems : Feature
	{
		public CommonSystems(Contexts contexts, ServicesCollection services)
			: base(nameof(CommonSystems))
		{
			Add(new ServicesRegistrationSystems(contexts, services));
			
			Add(new GameInitializationSystems(contexts));
			Add(new GameplaySystems(contexts));
			Add(new ViewSystems(contexts));
			
			Add(new GameCleanupSystems(contexts));
		}
	}
}
