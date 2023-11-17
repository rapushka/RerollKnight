using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class GameFeature : InjectableFeature
	{
		[Inject]
		public GameFeature(SystemsFactory factory)
			: base(nameof(GameFeature), factory)
		{
			// Registrations
			Add<RegisterBehavioursSystem>();

			// Initialization
			Add<SpawnFieldSystem>();
			Add<SpawnPlayerSystem>();
			Add<SpawnEnemySystem>();
			Add<InitializeActorsSystem>();

			Add<AddAbilityStateSystem>();
			Add<StoreChipPositionSystem>();
			Add<IdentifyChipsSystem>();

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