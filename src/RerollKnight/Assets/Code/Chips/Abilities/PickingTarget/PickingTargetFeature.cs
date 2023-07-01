namespace Code
{
	public sealed class PickingTargetFeature : Feature
	{
		public PickingTargetFeature(Contexts contexts)
			: base(nameof(PickingTargetFeature))
		{
			Add(new PickCellAsTargetSystem(contexts));
		}
	}
}