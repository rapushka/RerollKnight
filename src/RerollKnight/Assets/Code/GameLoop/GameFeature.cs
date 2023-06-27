namespace Code
{
	public sealed class GameFeature : Feature
	{
		public GameFeature(Contexts contexts, EntityBehaviourBase[] entityBehaviours)
			: base(nameof(GameFeature))
		{
			Add(new RegisterAllServicesSystem(contexts));
			Add(new RegisterEntityBehavioursSystem(contexts, entityBehaviours));

			Add(new StartGameSystem(contexts));

			Add(new SpawnFieldSystem(contexts));
			Add(new SpawnPlayerSystem(contexts));

			Add(new GameEventSystems(contexts));
		}
	}
}