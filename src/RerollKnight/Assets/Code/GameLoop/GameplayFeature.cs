using Zenject;

namespace Code
{
	public sealed class GameplayFeature : InjectableFeature
	{
		[Inject]
		public GameplayFeature(SystemsFactory factory)
			: base(nameof(GameplayFeature), factory)
		{
			Add<CollectActorsSystem>();

			Add<StartGameSystem>();

			// Game Logic
			Add<EmitAllRequestsSystem>();

			Add<UpdateGameplayStateMachineSystem>();
			Add<SpawnActorOnRequestSystem>();

			Add<MarkEmptyCellsSystem>();
			Add<EndTurnOnRequestSystem>();
			// Add<ChipsFeature>();
			// Add<AvailabilityFeature>();

			// Visuals
			Add<UpdateChipsPositionSystem>();
			// Add<UnhoverUnpickedChipSystem>();
			Add<MoveToDestinationSystem>();
			Add<SetPositionFromCoordinatesSystem>();
			Add<OutlineAvailableTargetsSystem>();
			Add<ViewCurrentActorSystem>();

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