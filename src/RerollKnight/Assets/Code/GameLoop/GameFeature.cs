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
			Add<StartGameSystem>();
			Add<SpawnFieldSystem>();
			Add<SpawnPlayerSystem>();
			Add<SpawnEnemySystem>();
			Add<MarkActorsSystem>();

			Add<AddAbilityStateSystem>();
			Add<StoreChipPositionSystem>();
			Add<IdentifyChipsSystem>();

			// Game Logic
			Add<EmitAllRequestsSystem>();

			Add<MarkEmptyCellsSystem>();
			// Add<ChipsFeature>();
			// Add<AvailabilityFeature>();
			Add<UpdateGameStateMachineSystem>();

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
			Add<DebugCurrentGameStateSystem>();
#endif

			Add<BoilerplateFeature>();
		}
	}
}