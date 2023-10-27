using Entitas;

namespace Code
{
	public class TurnEndedGameState : GameStateBase, IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<GameEntity> _targets;

		public TurnEndedGameState(GameStateMachine stateMachine, Contexts contexts) : base(stateMachine)
		{
			_contexts = contexts;
			_targets = _contexts.game.GetGroup(GameMatcher.PickedTarget);
		}

		public override void Enter()
		{
			StateMachine.ToState<ObservingGameState>();
		}

		public void Execute()
		{
			_contexts.game.pickedChipEntity.Unpick();

			foreach (var target in _targets.GetEntities())
				target.Unpick();
		}
	}
}