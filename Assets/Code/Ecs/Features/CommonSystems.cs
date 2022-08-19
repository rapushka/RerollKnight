using Code.Ecs.Systems.ExecuteSystems;
using Code.Ecs.Systems.InitializeSystems;
using Code.Unity.Services;

namespace Code.Ecs.Features
{
	public sealed class CommonSystems : Feature
	{
		public CommonSystems(Contexts contexts, ServicesCollection services)
			: base(nameof(CommonSystems))
		{
			Add(new ServicesRegistrationSystems(contexts, services));
			Add(new SetGravityScaleSystem(contexts));
			Add(new ApplyGravitySystem(contexts));
		}
	}
}
