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
		private readonly WindowsService _windows;

		[Inject]
		public OnRoomCompletedSystem
		(
			Contexts contexts,
			GameplayStateMachine stateMachine,
			WindowsService windows
		)
			: base(contexts.Get<GameScope>())
		{
			_stateMachine = stateMachine;
			_windows = windows;

			_enemies = contexts.GetGroup(AllOf(Get<Enemy>()).NoneOf(Get<Disabled>()));
			_players = contexts.GetGroup(Get<Player>());
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
		}

		private void OnRoomCleared()
			=> _stateMachine.ToState<WanderingGameplayState>();

		private void OnGameOver()
			=> _windows.Show<GameOverWindow>();
	}
}