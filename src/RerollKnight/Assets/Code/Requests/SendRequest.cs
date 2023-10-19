namespace Code
{
	public static class SendRequest
	{
		private static RequestContext Context => Contexts.sharedInstance.request;

		public static void UnpickAllTargets() => Context.CreateEntity().isUnpickAllTargets = true;

		public static void CastAbility() => Context.CreateEntity().isCastAbility = true;
	}
}