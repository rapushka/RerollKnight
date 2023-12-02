using Zenject;

namespace Code
{
	public class OtherPlayerTurnGameplayState : GameplayStateBase<OtherPlayerTurnGameplayState.StateFeature>
	{
		public OtherPlayerTurnGameplayState(IInstantiator container) : base(container) { }

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
				Add<PickRandomOurChip>();
				// _stateChangeBus.ToState<ChipPickedGameplayState>();

				// # Abilities
				Add<PrepareAbilitiesOfPickedChipSystem>();
				Add<AvailabilityFeature>();

				// Add<PickRandom<AvailableToPick>>();
				// Add<ToGameplayStateSystem<CastingAbilitiesGameplayState>>();

				Add<EndTurnWhenNoAvailableChipsSystem>();
			}
		}
	}
}