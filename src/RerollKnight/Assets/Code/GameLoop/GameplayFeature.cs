using Zenject;

namespace Code
{
	public sealed class GameplayFeature : InjectableFeature
	{
		[Inject]
		public GameplayFeature(SystemsFactory factory)
			: base(nameof(GameplayFeature), factory)
		{
			Add<StartGameSystem>();

			// Game Logic
			Add<EmitAllRequestsSystem>();

			Add<MarkEmptyCellsSystem>();
			// Add<ChipsFeature>();
			// Add<AvailabilityFeature>();
			Add<UpdateGameplayStateMachineSystem>();

			// Visuals
			Add<HoverPickedChipSystem>();
			Add<UnhoverUnpickedChipSystem>();
			Add<MoveToDestinationSystem>();
			Add<SetPositionFromCoordinatesSystem>();
			Add<OutlineAvailableTargetsSystem>();

			// Cleanups
			// Add<EndTurnSystem>();
			// Add<ResetAbilityStateSystem>();
#if DEBUG
			// Debug
			Add<DebugCurrentGameplayStateSystem>();
#endif

			Add<BoilerplateFeature>();
		}
	}
}