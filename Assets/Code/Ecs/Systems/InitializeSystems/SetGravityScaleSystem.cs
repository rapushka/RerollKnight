using Entitas;

namespace Code.Ecs.Systems.InitializeSystems
{
	public sealed class SetGravityScaleSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly float _gravityScale;

		public SetGravityScaleSystem(Contexts contexts)
		{
			_contexts = contexts;
			
			_gravityScale = contexts.game.balanceService.Value.GravityScale;
		}

		public void Initialize()
		{
			_contexts.game.gravityScale.Value = _gravityScale;
		}
	}
}
