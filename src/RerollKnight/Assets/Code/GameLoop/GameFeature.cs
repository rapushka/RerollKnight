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

			Add(new SpawnFieldSystem(contexts));
			Add(new SpawnPlayerSystem(contexts));

			// Game Logic
			Add(new StoreChipPositionSystem(contexts));
			Add(new ChipsPickingFeature(contexts));
			
			// Visuals
			Add(new HoverPickedChipSystem(contexts));
			Add(new UnhoverUnpickedChipSystem(contexts));
			Add(new MoveToDestinationSystem(contexts));

			// Entitas Generated
			Add(new GameEventSystems(contexts));
			Add(new GameCleanupSystems(contexts));
		}
	}
}