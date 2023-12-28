using Zenject;

namespace Code
{
	public sealed class GameplayFeature : InjectableFeature
	{
		[Inject]
		public GameplayFeature(SystemsFactory factory)
			: base(nameof(GameplayFeature), factory)
		{
			Add<ShowLoadingCurtainSystem>();
			Add<StartGameSystem>();

			// Game Logic
			Add<IdentifyAllEntitiesSystem<GameScope>>();
			Add<IdentifyAllEntitiesSystem<ChipsScope>>();
			Add<IdentifyAllEntitiesSystem<RequestScope>>();
			Add<EmitAllRequestsSystem>();

			// "Input" 
			Add<TransferDataSystem>();

			// Gameplay state machine
			Add<UpdateGameplayStateMachineSystem>();

			// Add<SpawnActorOnRequestSystem>();
			Add<MarkEmptyCellsSystem>();
			Add<EndTurnOnRequestSystem>();

			// Health
			Add<HealthFeature>();

			// Wandering around the Rooms
			Add<DestroyEmptyDoorSystem>();
			Add<OnRoomCompletedSystem>();
			Add<CascadeDisableSystem<GameScope>>();
			Add<CacheLayerOfDisabledSystem>();

			Add<PickRewardSystem>();

			// Turns queue
			Add<CollectActorsSystem>();
			Add<RemoveInactiveActorFromQueueSystem>();

			// Visuals
			Add<UpdateChipsPositionSystem>();
			Add<AlignChipsCenterSystem>();
			Add<MoveToDestinationSystem>();
			Add<DestroyAfterReachingDestinationSystem>();
			Add<RotateToDestinationSystem>();
			Add<LookAtSystem>();
			Add<SetPositionFromCoordinatesSystem>();
			// Add<OutlineHoveredTargetsSystem>();
			Add<OutlineTargetsSystem>();
			Add<WorldSpaceUiLookAtCameraSystem>();
			Add<ShowChipDescriptionSystem>();
			Add<AlignChipDescriptionAboveChipSystem>();
			Add<ShowDiceInfoSystem>();

#if DEBUG
			// Debug
			Add<DebugCurrentGameplayStateSystem>();
			Add<DebugTurnsQueueSystem>();

			// TMP
			// Add<TestPathfindingSystem>();
#endif

			Add<BoilerplateFeature>();

			// TearDown
			Add(new ClearReactivitySystem(this));
			Add<ResetContext<GameScope>>();
			Add<ResetContext<PlayerScope>>();
			Add<ResetContext<InputScope>>();
			Add<ResetContext<RequestScope>>();
			Add<ResetContext<ChipsScope>>();
			Add<ResetContext<InfrastructureScope>>();

			Add<HideLoadingCurtainImmediatelySystem>();
		}
	}
}