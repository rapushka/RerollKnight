using Entitas;

namespace Code
{
	public abstract class GameStateBase : StateBase<GameStateMachine>, IExitableState, IUpdatableState
	{
		public abstract void Exit();
		public abstract void OnUpdate();
	}

	public abstract class GameStateBase<TFeature> : GameStateBase
		where TFeature : Systems
	{
		private readonly TFeature _systems;

		protected GameStateBase(TFeature systems)
		{
			_systems = systems;
		}

		public override void Enter()
		{
			_systems.Initialize();
		}

		public override void OnUpdate()
		{
			_systems.Execute();
			_systems.Cleanup();
		}

		public override void Exit()
		{
			_systems.TearDown();
		}
	}
}