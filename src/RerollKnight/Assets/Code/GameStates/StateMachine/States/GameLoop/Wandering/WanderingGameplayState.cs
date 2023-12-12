using Zenject;

namespace Code
{
	public class WanderingGameplayState : GameplayStateBase<WanderingGameplayState.StateFeature>
	{
		public WanderingGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(WanderingGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				// Disable stuff
				// Spawn doors

				// Execute
				// On Door click:
				// - move player to opposite door
				// - exit prev room
				// - enter next room
			}
		}
	}
}