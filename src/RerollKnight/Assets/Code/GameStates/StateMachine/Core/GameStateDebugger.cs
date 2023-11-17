using System.Collections.Generic;
using System.Linq;
using Entitas.VisualDebugging.Unity;
using UnityEngine;
using Zenject;

namespace Code
{
#if DEBUG
	public class GameplayStateDebugger : MonoBehaviour, IInitializable
	{
		private Dictionary<DebugSystemsBehaviour, string> _systems;
		private GameplayStateMachine _stateMachine;

		[Inject]
		public void Construct(GameplayStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		void IInitializable.Initialize()
		{
			_systems = FindObjectsOfType<DebugSystemsBehaviour>().ToDictionary((s) => s, (s) => s.name);
		}

		private void Update()
		{
			var currentStateName = _stateMachine.CurrentState.GetType().Name;

			foreach (var (behaviour, stateName) in _systems)
			{
				behaviour.name = stateName.Contains(currentStateName)
					? stateName + "\t<- current"
					: stateName;
			}
		}
	}
#endif
}