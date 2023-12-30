using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class UnpickChipSystem : ReactiveSystem<Entity<GameScope>>, IStateTransferSystem
	{
		private readonly AudioService _audio; // TODO: REMOVE!!!

		public UnpickChipSystem(Contexts contexts, AudioService audio) : base(contexts.Get<GameScope>())
		{
			_audio = audio;
		}

		public StateMachineBase StateMachine { get; set; }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Clicked>(), Get<PickedChip>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
			{
				_audio.Play(Sound.ChipClick);
				e.Is<Clicked>(false);
				StateMachine.ToState<ObservingGameplayState>();
			}
		}
	}
}