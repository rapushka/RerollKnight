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
			Add<RegisterEntityBehavioursSystem>();

			// Initialization
			Add<StartGameSystem>();
			Add<SpawnFieldSystem>();
			Add<SpawnPlayerSystem>();

			Add<AddAbilityStateSystem>();
			Add<StoreChipPositionSystem>();

			// Game Logic
			Add<MarkEmptyCellsSystem>();
			Add<ChipsFeature>();

			// Visuals
			Add<HoverPickedChipSystem>();
			Add<UnhoverUnpickedChipSystem>();
			Add<MoveToDestinationSystem>();
			Add<SetPositionFromCoordinatesSystem>();

			// Cleanups
			Add<EndTurnSystem>();
			Add<ResetAbilityStateSystem>();

#if UNITY_EDITOR
			// Debug
			Add<DebugCurrentGameStateSystem>();
#endif

			// Entitas Generated
			Add<GameEventSystems>();
			Add<GameCleanupSystems>();
			Add<RequestCleanupSystems>();
		}
	}
}