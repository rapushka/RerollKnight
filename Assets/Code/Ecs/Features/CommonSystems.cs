using Code.Ecs.Systems.InitializeSystems;

namespace Code.Ecs.Features
{
	public sealed class CommonSystems : Feature
	{
		public CommonSystems(Contexts contexts, float gravityScale)
		{
			Add(new GameWorldSetupSystem(contexts, gravityScale));
		}
	}
}
