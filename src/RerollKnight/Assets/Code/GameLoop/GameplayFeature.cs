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
			Add<ArrangeChipsViewsSystem>();
			Add<UpdateChipsPositionSystem>();
			Add<MoveToDestinationSystem>();
			Add<SetPositionFromCoordinatesSystem>();
			Add<OutlineAvailableTargetsSystem>();
			Add<ViewCurrentActorSystem>();

#if DEBUG
			// Debug
			Add<DebugCurrentGameplayStateSystem>();
			Add<DebugTurnsQueueSystem>();
#endif

			Add<BoilerplateFeature>();
		}
	}
}