using Entitas;

namespace Code.Ecs.Systems.InitializeSystems
{
	public sealed class BindRigidbodyViewSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public BindRigidbodyViewSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			
		}
	}
}
