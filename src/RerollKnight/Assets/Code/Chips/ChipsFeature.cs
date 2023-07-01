namespace Code
{
	public sealed class ChipsFeature : Feature
	{
		public ChipsFeature(Contexts contexts)
			: base(nameof(ChipsFeature))
		{
			Add(new ChipsPickingFeature(contexts));
			Add(new TargetPickingFeature(contexts));

			Add(new ConfirmCastSystem(contexts));

			Add(new AbilitiesFeature(contexts));
		}
	}
}