namespace Code
{
	public sealed class ChipsPickingFeature : Feature
	{
		public ChipsPickingFeature(Contexts contexts)
			: base(nameof(ChipsPickingFeature))
		{
			Add(new PickChipSystem(contexts));
		}
	}
}