using UnityEngine;

namespace Code
{
	public static class SendRequest
	{
		private static RequestContext Context => Contexts.sharedInstance.request;

		public static void UnpickTargets() => NewEntity.isUnpickAllTargets = true;

		public static void CastAbility() => NewEntity.isCastAbility = true;

		public static void MarkAllTargetsAvailable()   => SetAvailability(true);
		public static void MarkAllTargetsUnavailable() => SetAvailability(false);

		private static void SetAvailability(bool value) => NewEntity.ReplaceSetAllTargetsAvailability(value);

		private static RequestEntity NewEntity => Context.CreateEntity();
	}
}