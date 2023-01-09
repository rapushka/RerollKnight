namespace Code
{
	public sealed class GameSystems : Feature
	{
		public GameSystems(Contexts contexts)
			: base(nameof(GameSystems))
		{
			Add(new SpawnEnemySystem(contexts));
		}	
	}
}