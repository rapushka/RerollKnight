using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class WaitingSystem : ReadyOnConditionSystemBase, IExecuteSystem, IDataReceiver<float>
	{
		private readonly ITimeService _time;

		private float _wholeDuration;
		private float _spentDuration;

		[Inject]
		public WaitingSystem(Contexts contexts, ITimeService time)
			: base(contexts)
			=> _time = time;

		public void SetData(float value)
		{
			_wholeDuration = value;
		}

		public override void Initialize()
		{
			base.Initialize();

			_spentDuration = 0;
		}

		public void Execute()
		{
			if (Ready)
				return;

			_spentDuration += _time.DeltaTime;

			if (_spentDuration >= _wholeDuration)
				Ready = true;
		}
	}
}