using Entitas;

namespace Code
{
	public sealed class EndTurnSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<GameEntity> _targets;

		public EndTurnSystem(Contexts contexts)
		{
			_contexts = contexts;
			_targets = _contexts.game.GetGroup(GameMatcher.PickedTarget);
		}

		public void Execute()
		{
			if (!_contexts.GameStateIs(GameState.WaitingForAbilityUsage))
				return;

			_contexts.ToGameState(GameState.TurnEnded);
			_contexts.game.pickedChipEntity.Unpick();

			foreach (var target in _targets.GetEntities())
				target.Unpick();
		}
	}
}