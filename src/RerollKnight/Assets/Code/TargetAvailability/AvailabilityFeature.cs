using Zenject;

namespace Code
{
	public sealed class AvailabilityFeature : InjectableFeature
	{
		[Inject]
		public AvailabilityFeature(SystemsFactory factory)
			: base(nameof(AvailabilityFeature), factory)
		{
			Add<MarkAllTargetsAvailableSystem>();
			// Add<SetAllAvailabilitySystem>();

			Add<MarkDisabledUnavailableSystem>();
			Add<MarkUnavailableByRangeSystem>();
			Add<MarkUnavailableByInactiveRangeSystem>();
			Add<MarkUnavailableByComponentsSystem>();
			Add<MarkUnavailableByObstaclesSystem>();
			Add<MarkUnavailableByVisibilitySystem>();
		}
	}
}