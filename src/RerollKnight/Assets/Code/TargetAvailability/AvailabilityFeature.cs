using Zenject;

namespace Code
{
	public sealed class AvailabilityFeature : InjectableFeature
	{
		[Inject]
		public AvailabilityFeature(SystemsFactory factory)
			: base(nameof(AvailabilityFeature), factory)
		{
			// Add<SetAllAvailabilitySystem>();
			Add<MarkUnavailableByRangeSystem>();
			Add<MarkUnavailableByComponentsSystem>();
		}
	}
}