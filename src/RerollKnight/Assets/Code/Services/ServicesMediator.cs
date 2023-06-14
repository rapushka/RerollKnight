namespace Code
{
	public static class ServicesMediator
	{
		private static ServicesContext Context => Contexts.sharedInstance.services;

		public static IResourcesService Resources => Context.resources.Value;
	}
}