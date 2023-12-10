using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class WaitingSystem : ReadyOnConditionSystemBase, IExecuteSystem, IDataReceiver<float>
	{
		private readonly ITimeService _time;

		[Inject]
		public WaitingSystem(Contexts contexts, ITimeService time)
			: base(contexts)
			=> _time = time;

		public float Value { get; set; }

		private float WholeDuration => Value;

		public override void Initialize()
		{
			base.Initialize();

			ReadinessEntity
				.Add<SpentTime, float>(0f)
				.Add<WholeTime, float>(Value)
				;
		}

		public void Execute()
		{
			if (Ready)
				return;

			var nextSpentTime = ReadinessEntity.Get<SpentTime>().Value + _time.DeltaTime;
			ReadinessEntity.Replace<SpentTime, float>(nextSpentTime);

			if (nextSpentTime >= WholeDuration)
				Ready = true;
		}
	}
}