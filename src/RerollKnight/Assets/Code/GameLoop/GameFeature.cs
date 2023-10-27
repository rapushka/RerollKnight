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

			Add(new AddAbilityStateSystem(contexts));
			Add(new StoreChipPositionSystem(contexts));

			// Game Logic
			Add(new MarkEmptyCellsSystem(contexts));
			Add(new ChipsFeature(contexts));

			// Visuals
			Add(new HoverPickedChipSystem(contexts));
			Add(new UnhoverUnpickedChipSystem(contexts));
			Add(new MoveToDestinationSystem(contexts));

			// Cleanups
			Add(new EndTurnSystem(contexts));
			Add(new ResetAbilityStateSystem(contexts));

#if UNITY_EDITOR
			// Debug
			Add(new DebugCurrentGameStateSystem(contexts));
#endif

			// Entitas Generated
			Add(new GameEventSystems(contexts));
			Add(new GameCleanupSystems(contexts));
			Add(new RequestCleanupSystems(contexts));
		}
	}
}