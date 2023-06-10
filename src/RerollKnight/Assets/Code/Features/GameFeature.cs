namespace Code
{
	public sealed class GameFeature : Feature
	{
		public GameFeature(Contexts contexts, EntityBehaviourBase[] entityBehaviours)
			: base(nameof(GameFeature))
		{
			Add(new RegisterEntityBehavioursSystem(contexts, entityBehaviours));
		}	
	}
}