using System;

namespace Code
{
	public sealed class ServicesRegistrationFeature : Feature
	{
		public ServicesRegistrationFeature(Contexts contexts)
			: base(nameof(ServicesRegistrationFeature))
		{
			var context = contexts.services;
			// Register(new SceneTransferService(), context.ReplaceSceneTransfer);
		}
		
		private void Register<T>(T service, Action<T> replaceService)
			=> Add(new RegisterServiceSystem<T>(service, replaceService));
	}
}