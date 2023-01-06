namespace Code
{
	public class EntitasPlayerContextAdapter : EntitasAdapterBase
	{
		protected override Feature GetFeature() => new PlayerFeature(Contexts.sharedInstance);
	}
}