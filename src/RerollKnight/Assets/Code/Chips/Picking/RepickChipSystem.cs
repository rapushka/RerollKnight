using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class RepickChipSystem : ReactiveSystem<Entity<GameScope>>, IStateTransferSystem
	{
		private readonly AudioService _audio; // TODO: REMOVE!!!

		[Inject]
		public RepickChipSystem(Contexts contexts, AudioService audio) : base(contexts.Get<GameScope>())
		{
			_audio = audio;
		}

		public StateMachineBase StateMachine { get; set; }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Clicked>(), Get<Chip>()).NoneOf(Get<PickedChip>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites.Where((e) => e.Is<AvailableToPick>()))
			{
				_audio.Play(Sound.ChipClick);
				StateMachine.ToState<ObservingGameplayState>();
				// _entitiesManipulator.UnpickAll(immediately: true);
				// RequestEmitter.Instance.Send<MarkAllTargetsAvailableRequest>();
				e.Pick();
				e.Is<Clicked>(false);
				StateMachine.ToState<ChipPickedGameplayState>();
			}
		}
	}
}