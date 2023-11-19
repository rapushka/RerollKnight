using Entitas;
using Entitas.Generic;

namespace Code
{
	public class ReadyOnTurnsQueueAny : ReadyOnConditionSystemBase, IExecuteSystem
	{
		private readonly TurnsQueue _turnsQueue;

		protected ReadyOnTurnsQueueAny(Contexts contexts, TurnsQueue turnsQueue) : base(contexts)
		{
			_turnsQueue = turnsQueue;
		}

		public override void Initialize()
		{
			base.Initialize();

			Ready = _turnsQueue.Any();
		}

		public void Execute()
		{
			Ready = _turnsQueue.Any();
		}
	}
}