namespace Code
{
	public sealed class TargetPickingFeature : Feature
	{
		public TargetPickingFeature(Contexts contexts)
			: base(nameof(TargetPickingFeature))
		{
			Add(new PrepareAbilitiesOfPickedChipSystem(contexts));

			Add(new PickCellAsTargetSystem(contexts));
			Add(new EnsureEmptyCellTargetConstraintSystem(contexts));

			Add(new ValidateMaxCountOfTargetsOverflowSystem(contexts));
			Add(new CastOnMaxCountOfTargetsSystem(contexts));
		}
	}
}