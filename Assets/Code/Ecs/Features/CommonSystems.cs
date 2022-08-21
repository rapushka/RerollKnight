using Code.Unity.Services;

namespace Code.Ecs.Features
{
	public sealed class CommonSystems : Feature
	{
		public CommonSystems(Contexts contexts, ServicesCollection services)
			: base(nameof(CommonSystems))
		{
			Add(new ServicesRegistrationSystems(contexts, services));
			Add(new GameInitializeSystems(contexts));
			Add(new GameplaySystems(contexts));
			Add(new GameEventSystems(contexts));
		}
	}
}
