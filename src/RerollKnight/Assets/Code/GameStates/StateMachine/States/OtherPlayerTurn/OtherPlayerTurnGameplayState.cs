using Entitas;
using UnityEngine;

namespace Code
{
	public class OtherPlayerTurnGameplayState : GameplayStateBase<OtherPlayerTurnGameplayState.StateFeature>
	{
		public OtherPlayerTurnGameplayState(StateFeature systems) : base(systems) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(OtherPlayerTurnGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<SayHiSystem>();
				Add<ToGameplayStateSystem<ObservingGameplayState>>();
			}
		}
	}

	public class SayHiSystem : IInitializeSystem
	{
		public void Initialize()
		{
			Debug.Log("it's enemy's turn!");
		}
	}
}