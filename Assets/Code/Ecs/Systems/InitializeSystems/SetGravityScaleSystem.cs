using Entitas;

namespace Code.Ecs.Systems.InitializeSystems
{
	public sealed class SetGravityScaleSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly float _gravityScale;

		public SetGravityScaleSystem(Contexts contexts, float gravityScale)
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
