using Code.Ecs.Systems.ExecuteSystems;
using Code.Ecs.Systems.InitializeSystems;
using Code.Ecs.Systems.ReactiveSystems;
using Code.Unity.Services;

namespace Code.Ecs.Features
{
	public sealed class CommonSystems : Feature
	{
		public CommonSystems(Contexts contexts, ServicesCollection services)
			: base(nameof(CommonSystems))
		{
			Add(new ServicesRegistrationSystems(contexts, services));
			Add(new SpawnPlayerSystem(contexts));
			Add(new BindPositionViewSystem(contexts));
			// Add(new ApplyGravitySystem(contexts));
		}
	}
}
