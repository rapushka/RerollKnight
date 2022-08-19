using Code.Ecs.Systems.ExecuteSystems;
using Code.Unity.Services;

namespace Code.Ecs.Features
{
	public sealed class CommonSystems : Feature
	{
		public CommonSystems(Contexts contexts, ServicesCollection services)
			: base(nameof(CommonSystems))
		{
			Add(new ServicesRegistrationSystems(contexts, services));
			Add(new ApplyGravitySystem(contexts));
		}
	}
}
