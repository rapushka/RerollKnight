using Zenject;

namespace Code
{
	public abstract class GameplayStateBase : StateBase, IExitableState, IUpdatableState
	{
		public abstract void Exit();
		public abstract void Execute();
		public abstract void Cleanup();
	}

	public abstract class GameplayStateBase<TFeature> : GameplayStateBase
		where TFeature : StateFeatureBase
	{
		private readonly TFeature _systems;

		protected GameplayStateBase(IInstantiator container)
		{
			_systems = container.Instantiate<TFeature>();
		}

		public override void Enter(StateMachineBase stateMachine)
		{
			_systems.StateMachine = stateMachine;
			_systems.Initialize();
		}

		public override void Execute() => _systems.Execute();

		public override void Cleanup() => _systems.Cleanup();

		public override void Exit() => _systems.TearDown();
	}
}