using Zenject;

namespace Code
{
	public class RerollDicesGameplayState : GameplayStateBase<RerollDicesGameplayState.StateFeature>
	{
		public RerollDicesGameplayState(IInstantiator container) : base(container) { }

		public sealed class StateFeature : StateFeatureBase
		{
			public StateFeature(SystemsFactory factory, IViewConfig viewConfig)
				: base($"{nameof(RerollDicesGameplayState)}.{nameof(StateFeature)}", factory)
			{
				// Initialize
				Add<MarkAllDicesDetachedSystem>();
				Add<ThrowDicesSystem>();
				Add<RandomRotationSystem>();

				Add<WaitingSystem, float>(viewConfig.RerollDuration);

				// Add<PassTurnToNextActorSystem>();

				Add<ToStateWhenAllReady<PassTurnGameplayState>>();
				// Add<ToStateWhenAllReady<TurnEndedGameplayState>>();

				// Audio
				Add<PlayRerollSoundSystem>();

				// TearDown
				Add<SetRandomSideRolledSystem>();
				Add<MarkDefinedSideAsActiveSystem>();
				Add<UnMarkAllDicesDetachedSystem>();
				// Add<MarkAvailableChipsSystem>();
			}
		}
	}
}