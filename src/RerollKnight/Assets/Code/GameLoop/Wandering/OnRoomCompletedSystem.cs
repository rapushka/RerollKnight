using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class OnRoomCompletedSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly GameplayStateMachine _stateMachine;
		private readonly IGroup<Entity<GameScope>> _enemies;
		private readonly IGroup<Entity<GameScope>> _players;
		private readonly IGroup<Entity<GameScope>> _notCompletedRooms;
		private readonly WindowsService _windows;
		private readonly MapProvider _mapProvider;
		private readonly RewardFactory _rewardFactory;

		[Inject]
		public OnRoomCompletedSystem
		(
			Contexts contexts,
			GameplayStateMachine stateMachine,
			WindowsService windows,
			MapProvider mapProvider,
			RewardFactory rewardFactory
		)
			: base(contexts.Get<GameScope>())
		{
			_stateMachine = stateMachine;
			_windows = windows;
			_mapProvider = mapProvider;
			_rewardFactory = rewardFactory;

			_enemies = contexts.GetGroup(AllOf(Get<Enemy>()).NoneOf(Get<Disabled>()));
			_players = contexts.GetGroup(Get<Player>());
			_notCompletedRooms = contexts.GetGroup(AllOf(Get<Room>()).NoneOf(Get<CompletedRoom>()));
		}

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AnyOf(Get<Player>(), Get<Enemy>()).Removed());

		protected override bool Filter(Entity<GameScope> entity) => true;

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			if (!_enemies.Any())
				OnRoomCleared();

			if (!_players.Any())
				OnGameOver();

			if (!_notCompletedRooms.Any())
				OnAllRoomsCleared();
		}

		private void OnAllRoomsCleared()
		{
			_windows.Show<EndOfDemoWindow>();
		}

		private void OnRoomCleared()
		{
			_mapProvider.CurrentRoom.Is<CompletedRoom>(true);
			_rewardFactory.Create();
			_stateMachine.ToState<WanderingGameplayState>();
		}

		private void OnGameOver()
			=> _windows.Show<GameOverWindow>();
	}
}