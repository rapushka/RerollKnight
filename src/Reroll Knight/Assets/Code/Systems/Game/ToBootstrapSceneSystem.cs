using Entitas;

namespace Code
{
	public sealed class ToBootstrapSceneSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public ToBootstrapSceneSystem(Contexts contexts) => _contexts = contexts;

		public void Initialize() => _contexts.services.sceneTransfer.Value.ToBootstrapScene();
	}
}