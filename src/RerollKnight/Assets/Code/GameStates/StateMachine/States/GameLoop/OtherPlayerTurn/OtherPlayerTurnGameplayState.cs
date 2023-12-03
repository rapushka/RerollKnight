using Code.Component;
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
				Add<PickRandom<Chip, AvailableToPick>>();
				// _stateChangeBus.ToState<ChipPickedGameplayState>();

				// # Abilities
				Add<PrepareAbilitiesOfPickedChipSystem>();
				Add<AvailabilityFeature>();
				Add<PickRandom<Target, AvailableToPick>>();

				// if casting a chip – will pass to Casting State
				Add<CastAbilitiesSystem>();
				// otherwise – turn will be ended
				Add<EndTurnOnOutOfChipsSystem>();
			}
		}
	}
}