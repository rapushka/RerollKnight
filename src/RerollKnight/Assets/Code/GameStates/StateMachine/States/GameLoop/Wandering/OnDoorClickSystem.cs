using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class OnDoorClickSystem : ReactiveSystem<Entity<GameScope>>, IStateTransferSystem
	{
		private readonly Contexts _contexts;
		private readonly IViewConfig _viewConfig;
		private TurnsQueue _turnsQueue;

		[Inject]
		public OnDoorClickSystem(Contexts contexts, IViewConfig viewConfig, TurnsQueue turnsQueue)
			: base(contexts.Get<GameScope>())
		{
			_contexts = contexts;
			_viewConfig = viewConfig;
			_turnsQueue = turnsQueue;
		}

		public StateMachineBase StateMachine { get; set; }

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<DoorTo>(), Get<Clicked>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var door in entities)
			{
				var coordinates = door.GetCoordinates(withLayer: Coordinates.Layer.Default);
				if (CurrentActor is null)
					_turnsQueue.Next().Is<CurrentActor>(true);

				CurrentActor!.Replace<Component.Coordinates, Coordinates>(coordinates);
				var roomOfDoor = door.Get<DoorTo>().Value;
				roomOfDoor.Is<NextRoom>(true);

				StateMachine.WaitAndThenToState<EnterRoomGameplayState>(_viewConfig.RoomTransferDuration);
			}
		}
	}
}