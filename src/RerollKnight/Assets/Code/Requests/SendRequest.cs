namespace Code
{
	public static class SendRequest
	{
		private static RequestContext Context => Contexts.sharedInstance.request;

		public static void UnpickTargets() => NewEntity.isUnpickAllTargets = true;

		public static void CastAbility() => NewEntity.isCastAbility = true;

		public static void MarkAllTargetsAvailable() => NewEntity.isMarkAllTargetsAvailable = true;

		private static RequestEntity NewEntity => Context.CreateEntity();
	}
}