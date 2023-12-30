using Entitas;
using Zenject;

namespace Code
{
	public sealed class RerollIfNeededSystem : IInitializeSystem, IStateTransferSystem
	{
		private readonly TurnsQueue _turnsQueue;

		[Inject]
		public RerollIfNeededSystem(TurnsQueue turnsQueue)
		{
			_turnsQueue = turnsQueue;
		}

		public StateMachineBase StateMachine { get; set; }

		public void Initialize()
		{
			if (_turnsQueue.CurrentIsLast || RequestRerollDirtyFlag.IsNeeded)
				StateMachine.ToState<RerollDicesGameplayState>();
			else
				StateMachine.ToState<PassTurnGameplayState>();

			RequestRerollDirtyFlag.IsNeeded = false;
		}
	}
}