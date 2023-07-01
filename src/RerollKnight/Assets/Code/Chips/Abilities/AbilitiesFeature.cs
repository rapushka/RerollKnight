namespace Code
{
	public sealed class AbilitiesFeature : Feature
	{
		public AbilitiesFeature(Contexts contexts)
			: base(nameof(AbilitiesFeature))
		{
			Add(new DebugTeleportSystem(contexts));
		}
	}
}