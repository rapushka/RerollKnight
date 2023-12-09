using System.Collections.Generic;
using Zenject;

namespace Code
{
	public class GameplayStateMachine : StateMachineBase
	{
		[Inject]
		public GameplayStateMachine(IEnumerable<IState> states)
		{
			foreach (var state in states)
				AddState(state);
		}
	}
}