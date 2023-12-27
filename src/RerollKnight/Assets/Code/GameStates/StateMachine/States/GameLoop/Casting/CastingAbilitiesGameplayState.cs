using Zenject;

namespace Code
{
	public class CastingAbilitiesGameplayState : GameplayStateBase<CastingAbilitiesGameplayState.StateFeature>
	{
		public CastingAbilitiesGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(CastingAbilitiesGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<MarkAllAbilitiesCastingSystem>();

				Add<BattleLogAbilitiesSystem>();

				Add<MarkAllTargetsUnavailableSystem>();
				Add<MarkPickedChipUnavailableSystem>();

				Add<AbilitiesFeature>();
				Add<ToCurrentActorStateSystem>();
				// Add<ToCurrentActorStateIfNotRerollSystem>();

				// Update
				// Add<EndTurnSystem>();

				// Tear down
				Add<ResetAbilityStateSystem>();
			}
		}
	}
}