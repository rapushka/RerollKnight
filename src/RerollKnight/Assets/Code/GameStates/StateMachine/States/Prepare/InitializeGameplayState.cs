using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public class InitializeGameplayState : GameplayStateBase<InitializeGameplayState.StateFeature>
	{
		public InitializeGameplayState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(InitializeGameplayState)}.{nameof(StateFeature)}", factory)
			{
				Add<AddAbilityStateSystem>();
				Add<StoreChipPositionSystem>();
				Add<IdentifyChipsSystem>();

				// Ready
				Add<ReadyOnAny<Actor>>();
				Add<PutPlayerFirstSystem>();

				// TODO: is it the best state?
				Add<ToStateWhenAllReady<TurnEndedGameplayState>>();
			}
		}
	}

	public sealed class PutPlayerFirstSystem : IInitializeSystem
	{
		private readonly TurnsQueue _turnsQueue;
		private readonly IGroup<Entity<GameScope>> _players;

		public PutPlayerFirstSystem(Contexts contexts, TurnsQueue turnsQueue)
		{
			_turnsQueue = turnsQueue;
			_players = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Player>());
		}

		public void Initialize()
		{
			foreach (var player in _players)
				_turnsQueue.PutFirst(player);
		}
	}
}