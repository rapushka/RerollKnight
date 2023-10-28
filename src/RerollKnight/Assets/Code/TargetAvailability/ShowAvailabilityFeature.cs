using Zenject;

namespace Code
{
	public sealed class ShowAvailabilityFeature : InjectableFeature
	{
		[Inject]
		public ShowAvailabilityFeature(SystemsFactory factory)
			: base(nameof(ShowAvailabilityFeature), factory)
		{
			Add<MarkAllAvailableSystem>();
			Add<MarkUnavailableByRangeSystem>();
			Add<MarkUnavailableByComponentsSystem>();
		}
	}
}