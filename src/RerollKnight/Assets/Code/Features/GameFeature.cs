namespace Code
{
	public sealed class GameFeature : Feature
	{
		public GameFeature(Contexts contexts, GameEntityBehaviourOld[] entityBehaviours)
			: base(nameof(GameFeature))
		{
			Add(new InitializeGameEntityBehavioursSystem(contexts, entityBehaviours));
		}	
	}
}