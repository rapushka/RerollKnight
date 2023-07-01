namespace Code
{
	public sealed class PickingTargetFeature : Feature
	{
		public PickingTargetFeature(Contexts contexts)
			: base(nameof(PickingTargetFeature))
		{
			Add(new PrepareAbilitiesOfPickedChipSystem(contexts));

			Add(new PickCellAsTargetSystem(contexts));
			Add(new EnsureEmptyCellTargetConstraintSystem(contexts));
		}
	}
}