using UnityEngine;

namespace Code
{
	public abstract class GameStateBase : StateBase<GameStateMachine>
	{
		protected GameStateBase(GameStateMachine stateMachine) : base(stateMachine) { }
	}

	public class SomeGameState : GameStateBase
	{
		public SomeGameState(GameStateMachine stateMachine) : base(stateMachine) { }

		public override void Enter()
		{
			Debug.Log("hi!!!");
			StateMachine.ToState<AnotherGameState>();
		}
	}

	public class AnotherGameState : GameStateBase
	{
		public AnotherGameState(GameStateMachine stateMachine) : base(stateMachine) { }

		public override void Enter() { }
	}
}