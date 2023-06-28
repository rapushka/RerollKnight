namespace Code
{
	public sealed class GameFeature : Feature
	{
		public GameFeature(Contexts contexts, EntityBehaviourBase[] entityBehaviours)
			: base(nameof(GameFeature))
		{
			// Registrations
			Add(new RegisterAllServicesSystem(contexts));
			Add(new RegisterEntityBehavioursSystem(contexts, entityBehaviours));

			// Initialization
			Add(new StartGameSystem(contexts));
			Add(new DebugCurrentGameStateSystem(contexts));

			Add(new SpawnFieldSystem(contexts));
			Add(new SpawnPlayerSystem(contexts));

			Add(new StoreChipPositionSystem(contexts));

			// Game Logic
			Add(new ChipsPickingFeature(contexts));
			Add(new PickCellAsTargetSystem(contexts));

			Add(new UnpickTargetsOnGameStateSystem(contexts));
			Add(new UnpickAllTargetsOnRequestSystem(contexts));

			// Abilities
			Add(new DebugTeleportSystem(contexts));

			// Visuals
			Add(new HoverPickedChipSystem(contexts));
			Add(new UnhoverUnpickedChipSystem(contexts));
			Add(new MoveToDestinationSystem(contexts));

			// Entitas Generated
			Add(new GameEventSystems(contexts));
			Add(new GameCleanupSystems(contexts));
			Add(new RequestCleanupSystems(contexts));
		}
	}
}