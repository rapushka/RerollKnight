using Code.Component;

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
				// # Clean
				Add<UnpickAllSystem>();
				Add<MarkAllTargetsUnavailableSystem>();

				// # Cell
				Add<PickRandom<Chip>>();
				// _stateChangeBus.ToState<ChipPickedGameplayState>();

				// # Abilities
				Add<PrepareAbilitiesOfPickedChipSystem>();
				Add<AvailabilityFeature>();

				// TODO: won't work for multi-target abilities
				// BUT, "multi-target abilities" is bs imo. so..s
				Add<PickRandom<AvailableToPick>>();
				Add<CastAbilitiesSystem>();

				// Add<EndTurnSystem>();
			}
		}
	}
}