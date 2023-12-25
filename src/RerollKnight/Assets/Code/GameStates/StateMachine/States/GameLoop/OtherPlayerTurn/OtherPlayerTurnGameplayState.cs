using Zenject;

namespace Code
{
	public class OtherPlayerTurnGameplayState : GameplayStateBase<OtherPlayerTurnGameplayState.StateFeature>
	{
		public OtherPlayerTurnGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(OtherPlayerTurnGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<UnpickAllSystem>();
				Add<MarkAllTargetsUnavailableSystem>();

				// 🧐
				Add<ChooseEnemyStrategySystem>();
				Add<UpdateDistanceToPlayerSystem>();
				Add<TryAttackSystem>();
				Add<MoveToPlayerSystem>();
				Add<RunAwayOnDefenceSystem>();

				Add<PrepareAbilitiesOfPickedChipSystem>();
				// Add<AvailabilityFeature>();

				// Add<PickRandom<Target, AvailableToPick>>();
				// Add<HandleMultiTargetAbilitySystem>();

				// if casting a chip – will pass to Casting State
				Add<CastAbilitiesSystem>();
				// otherwise – turn will be ended
				Add<EndTurnOnStrategySystem>();
				// Add<EndTurnOnOutOfChipsSystem>();
			}
		}
	}
}