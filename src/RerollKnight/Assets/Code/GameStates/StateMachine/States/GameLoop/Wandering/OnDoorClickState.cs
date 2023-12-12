using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class OnDoorClickState : ReactiveSystem<Entity<GameScope>>, IStateTransferSystem
	{
		private readonly Contexts _contexts;
		private readonly IViewConfig _viewConfig;

		public OnDoorClickState(Contexts contexts)
			: base(contexts.Get<GameScope>())
			=> _contexts = contexts;

		public StateMachineBase StateMachine { get; set; }

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<DoorTo>(), Get<Clicked>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var door in entities)
			{
				var coordinates = door.GetCoordinates(withLayer: Coordinates.Layer.Default);
				CurrentActor.Replace<Component.Coordinates, Coordinates>(coordinates);

				StateMachine.WaitAndThenToState<EnterRoomGameplayState>(_viewConfig.RoomTransferDuration);
			}
		}
	}
}