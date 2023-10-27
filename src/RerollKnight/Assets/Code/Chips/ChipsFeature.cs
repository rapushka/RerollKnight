namespace Code
{
	public sealed class ChipsFeature : InjectableFeature
	{
		public ChipsFeature(SystemsFactory factory)
			: base(nameof(ChipsFeature), factory)
		{
			Add<ChipsPickingFeature>();

			Add<UnpickAllOnRequestSystem>();

			Add<TargetPickingFeature>();

			// Add<MarkAbilitiesCastedBySystem>();

			Add<AbilitiesFeature>();
		}
	}
}