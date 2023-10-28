using Entitas;
using Zenject;
using static ChipsMatcher;
using static GameMatcher;

namespace Code
{
	public sealed class CastTeleportSystem : IExecuteSystem
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly IGroup<GameEntity> _players;
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<ChipsEntity> _abilities;

		[Inject]
		public CastTeleportSystem(Contexts contexts, GameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;

			_players = contexts.game.GetGroup(Player);
			_targets = contexts.game.GetGroup(PickedTarget);
			_abilities = contexts.chips.GetGroup(AllOf(Teleport, State));
		}

		public void Execute()
		{
			if (_gameStateMachine.CurrentState is not WaitingGameState)
				return;

			foreach (var ability in _abilities.WhereStateIs(AbilityState.Casting))
			foreach (var player in _players)
			foreach (var target in _targets)
			{
				player.ReplaceCoordinates(target.GetCoordinates());
				ability.ReplaceState(AbilityState.Casted);
			}
		}
	}
}