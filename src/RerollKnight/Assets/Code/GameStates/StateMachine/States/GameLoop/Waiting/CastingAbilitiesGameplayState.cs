using Zenject;

namespace Code
{
	public class CastingAbilitiesGameplayState : GameplayStateBase<CastingAbilitiesGameplayState.StateFeature>
	{
		public CastingAbilitiesGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : InjectableFeature
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(CastingAbilitiesGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<MarkAllAbilitiesCastingSystem>();
				Add<AbilitiesFeature>();

				// Update
				Add<EndTurnSystem>();

				// Tear down
				Add<ResetAbilityStateSystem>();
			}
		}
	}
}