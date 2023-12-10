using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class StartRerollSystem : IInitializeSystem, IStateTransferSystem
	{
		private readonly TurnsQueue _turnsQueue;

		[Inject]
		public StartRerollSystem(Contexts contexts, TurnsQueue turnsQueue)
			=> _turnsQueue = turnsQueue;

		public StateMachineBase StateMachine { get; set; }

		public void Initialize()
		{
			if (_turnsQueue.CurrentIsLast)
				StateMachine.ToState<TossDicesGameplayState>();
		}
	}
}