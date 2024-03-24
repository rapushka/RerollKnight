using Zenject;

namespace Code
{
	public sealed class ChipsViewFeature : InjectableFeature
	{
		[Inject]
		public ChipsViewFeature(SystemsFactory factory)
			: base(nameof(GameplayFeature), factory)
		{
			Add<UpdateChipsPositionSystem>();
			Add<UpdateChipsRotationSystem>();
			Add<AlignChipsVerticallySystem>();
			Add<ShowChipDescriptionSystem>();
			Add<AlignChipDescriptionAboveChipSystem>();
		}
	}
}