using System;

namespace Code
{
	public abstract class SetTargetsAvailabilityRequest : Request
	{
		protected void SetAvailability(bool value) => NewEntity.ReplaceSetAllTargetsAvailability(value);
	}

	public class MarkAllTargetsAvailableRequest : SetTargetsAvailabilityRequest
	{
		public override Action Action => () => SetAvailability(true);
	}

	public class MarkAllTargetsUnavailableRequest : SetTargetsAvailabilityRequest
	{
		public override Action Action => () => SetAvailability(false);
	}
}