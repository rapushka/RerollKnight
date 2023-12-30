using Entitas;
using Entitas.Generic;

namespace Code
{
	public class WaitForOneFrameSystem : ReadyOnConditionSystemBase, IExecuteSystem
	{
		private const int FramesToWait = 1;
		private int _framesCounter;

		protected WaitForOneFrameSystem(Contexts contexts) : base(contexts) { }

		public override void Initialize()
		{
			base.Initialize();

			_framesCounter = 0;
		}

		public void Execute()
		{
			if (Ready)
				return;

			if (_framesCounter >= FramesToWait)
				Ready = true;

			_framesCounter++;
		}
	}
}