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

			// Turns queue
			Add<CollectActorsSystem>();
			Add<RemoveDestroyedActorFromQueueSystem>();

			// Visuals
			Add<UpdateChipsPositionSystem>();
			Add<AlignChipsCenterSystem>();
			Add<MoveToDestinationSystem>();
			Add<LookAtSystem>();
			Add<SetPositionFromCoordinatesSystem>();
			Add<OutlineAvailableTargetsSystem>();
			Add<WorldSpaceUiLookAtCameraSystem>();

#if DEBUG
			// Debug
			Add<DebugCurrentGameplayStateSystem>();
			Add<DebugTurnsQueueSystem>();
#endif

			Add<BoilerplateFeature>();
		}
	}
}