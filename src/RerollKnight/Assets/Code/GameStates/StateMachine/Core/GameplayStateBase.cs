using Entitas;

namespace Code
{
	public abstract class GameplayStateBase : StateBase<GameplayStateMachine>, IExitableState, IUpdatableState
	{
		public abstract void Exit();
		public abstract void OnUpdate();
	}

	public abstract class GameplayStateBase<TFeature> : GameplayStateBase
		where TFeature : Systems
	{
		private readonly TFeature _systems;

		protected GameplayStateBase(TFeature systems)
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