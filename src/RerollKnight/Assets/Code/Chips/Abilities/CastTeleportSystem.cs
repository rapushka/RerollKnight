using Entitas;
using static ChipsMatcher;
using static GameMatcher;

namespace Code
{
	public sealed class CastTeleportSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _players;
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<ChipsEntity> _abilities;

		public CastTeleportSystem(Contexts contexts)
		{
			_players = contexts.game.GetGroup(Player);
			_targets = contexts.game.GetGroup(PickedTarget);
			_abilities = contexts.chips.GetGroup(AllOf(Teleport, State));
		}

		public void Execute()
		{
			if (ServicesMediator.GameStateMachine.CurrentState is not WaitingGameState)
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