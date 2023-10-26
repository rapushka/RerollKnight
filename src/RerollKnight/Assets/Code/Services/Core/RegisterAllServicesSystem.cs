using Entitas;
using UnityEngine;

namespace Code
{
	public sealed class RegisterAllServicesSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public RegisterAllServicesSystem(Contexts contexts) => _contexts = contexts;

		public void Initialize()
		{
			_contexts.services.ReplaceResources(new ResourcesService());
			_contexts.services.ReplaceAssets(new AssetsService());
			_contexts.services.ReplaceLayout(Resources.Load<LayoutService>("Layout"));
		}
	}
}