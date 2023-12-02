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

			Add<UpdateGameplayStateMachineSystem>();

			// Add<SpawnActorOnRequestSystem>();
			Add<MarkEmptyCellsSystem>();
			Add<EndTurnOnRequestSystem>(); // todo: mb move to Observing state
			Add<CollectActorsSystem>();

			// Visuals
			Add<UpdateChipsPositionSystem>();
			Add<MoveToDestinationSystem>();
			Add<SetPositionFromCoordinatesSystem>();
			Add<OutlineAvailableTargetsSystem>();
			Add<ViewCurrentActorSystem>();

#if DEBUG
			// Debug
			Add<DebugCurrentGameplayStateSystem>();
#endif

			Add<BoilerplateFeature>();
		}
	}
}