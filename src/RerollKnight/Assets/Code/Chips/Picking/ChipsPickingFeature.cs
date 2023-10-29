namespace Code
{
	public sealed class ChipsPickingFeature : InjectableFeature
	{
		public ChipsPickingFeature(SystemsFactory factory)
			: base(nameof(ChipsPickingFeature), factory)
		{
			Add<UnpickChipSystem>();
			Add<RepickChipSystem>();
			Add<PickChipSystem>();

			Add<UnpickAllOnRequestSystem>();
		}
	}
}