namespace Code
{
	public sealed class GameFeature : Feature
	{
		public GameFeature(Contexts contexts, GameEntityBehaviour[] entityBehaviours)
			: base(nameof(GameFeature))
		{
			Add(new InitializeGameEntityBehavioursSystem(contexts, entityBehaviours));
		}	
	}
}