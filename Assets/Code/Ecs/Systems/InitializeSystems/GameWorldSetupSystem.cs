using Entitas;

namespace Code.Ecs.Systems.InitializeSystems
{
	public sealed class GameWorldSetupSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly float _gravityScale;

		public GameWorldSetupSystem(Contexts contexts, float gravityScale)
		{
			_contexts = contexts;
			_gravityScale = gravityScale;
		}

		public void Initialize()
		{
			_contexts.game.gravityScale.Value = _gravityScale;
		}
	}
}
