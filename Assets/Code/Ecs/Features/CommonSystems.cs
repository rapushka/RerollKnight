using Code.Ecs.Systems.InitializeSystems;
using Code.Unity.Services;

namespace Code.Ecs.Features
{
	public sealed class CommonSystems : Feature
	{
		public CommonSystems(Contexts contexts, ServicesCollection services)
		{
			Add(new SetGravityScaleSystem(contexts, services.Balance.GravityScale));
		}
	}
}
