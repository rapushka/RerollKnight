using Entitas;
using Zenject;

namespace Code
{
	public sealed class MarkAllTargetsAvailableSystem : IInitializeSystem
	{
		private readonly AvailabilityService _availability;

		[Inject]
		public MarkAllTargetsAvailableSystem(AvailabilityService availability)
			=> _availability = availability;

		public void Initialize() => _availability.MarkAllTargetsAvailable();
	}
}