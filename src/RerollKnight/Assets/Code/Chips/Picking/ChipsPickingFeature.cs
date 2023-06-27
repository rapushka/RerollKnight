namespace Code
{
	public sealed class ChipsPickingFeature : Feature
	{
		public ChipsPickingFeature(Contexts contexts)
			: base(nameof(ChipsPickingFeature))
		{
			Add(new UnpickChipSystem(contexts));
			Add(new RepickChipSystem(contexts));
			Add(new PickChipSystem(contexts));
		}
	}
}