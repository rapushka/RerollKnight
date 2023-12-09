using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class UnpickChipSystem : ReactiveSystem<Entity<GameScope>>, IStateTransferSystem
	{
		public UnpickChipSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }
		public StateMachineBase StateMachine { get; set; }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Clicked>(), Get<PickedChip>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
			{
				e.Is<Clicked>(false);
				StateMachine.ToState<ObservingGameplayState>();
			}
		}
	}
}