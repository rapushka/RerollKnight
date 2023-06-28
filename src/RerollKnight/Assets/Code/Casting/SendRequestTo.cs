namespace Code
{
	public static class SendRequestTo
	{
		private static RequestContext Context => Contexts.sharedInstance.request;

		public static void UnpickAllTargets() => Context.CreateEntity().isUnpickAllTargets = true;
	}
}