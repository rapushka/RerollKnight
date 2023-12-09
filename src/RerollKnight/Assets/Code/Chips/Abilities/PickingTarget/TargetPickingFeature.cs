namespace Code
{
	public sealed class TargetPickingFeature : StateFeatureBase
	{
		public TargetPickingFeature(SystemsFactory factory)
			: base(nameof(TargetPickingFeature), factory)
		{
			// Add<PrepareAbilitiesOfPickedChipSystem>();

			Add<PickTargetSystem>();

			// Add<ConstraintAbilityRangeSystem>();
			// Add<EnsureTargetConstraintComponentsSystem>();
			Add<ValidateMaxCountOfTargetsOverflowSystem>();

			Add<CastOnMaxCountOfTargetsSystem>();
		}
	}
}