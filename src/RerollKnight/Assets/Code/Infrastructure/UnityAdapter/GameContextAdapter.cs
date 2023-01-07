namespace Code
{
	public class GameContextAdapter : EntitasAdapterBase
	{
		protected override Feature GetFeature() => new GameSystems(Contexts);
	}
}