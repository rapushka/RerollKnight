using Entitas.Generic;

namespace Code.Editor.Tests
{
	public static class ContextsExtensions
	{
		public static void Initialize(this Contexts @this)
		{
			// ReSharper disable once ObjectCreationAsStatement - it'll still initialize contexts
			new ContextsInitializer(@this);
		}
	}
}