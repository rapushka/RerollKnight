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
		protected readonly TFeature Feature;

		protected GameplayStateBase(IInstantiator container)
		{
			Feature = container.Instantiate<TFeature>();
			// (Feature as IDataReceiver<GameplayStateBase<TFeature>>)?.SetData(this);
		}

		public override void Enter(StateMachineBase stateMachine)
		{
			Feature.StateMachine = stateMachine;
			Feature.Initialize();
		}

		public override void Execute() => Feature.Execute();

		public override void Cleanup() => Feature.Cleanup();

		public override void Exit() => Feature.TearDown();
	}
}