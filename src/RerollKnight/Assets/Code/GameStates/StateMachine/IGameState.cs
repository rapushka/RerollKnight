using UnityEngine;

namespace Code
{
	public interface IGameState : IState { }

	public class GameState1 : IGameState
	{
		private readonly GameStateMachine _stateMachine;

		public GameState1(GameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Enter()
		{
			Debug.Log("hi from state 1");
			_stateMachine.ToState<GameState2>();
		}
	}

	public class GameState2 : IGameState
	{
		public void Enter()
		{
			Debug.Log("hi from state 2");
		}
	}
}