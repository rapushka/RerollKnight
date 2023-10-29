using System;

namespace Code
{
	public class UnpickTargetsRequest : Request
	{
		public override Action Action => () => NewEntity.isUnpickAllTargets = true;
	}
}