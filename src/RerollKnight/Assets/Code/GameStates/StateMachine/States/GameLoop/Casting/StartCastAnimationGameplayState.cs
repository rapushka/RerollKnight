using Zenject;

namespace Code
{
	public class StartCastAnimationGameplayState : GameplayStateBase<StartCastAnimationGameplayState.StateFeature>
	{
		public StartCastAnimationGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory)
				: base($"{nameof(StartCastAnimationGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<TurnCasterToTargetSystem>();
				Add<SpawnHoldingItemInHandSystem>();
				Add<PlayCastAnimationSystem>();

				// Walking
				Add<ReadyWhenHasNoPathSystem>();
				Add<MoveToNextCellInPathSystem>();

				Add<PrepareAnimationSystem>();

				Add<ToStateWhenAllReady<CastingAbilitiesGameplayState>>();
			}
		}
	}
}