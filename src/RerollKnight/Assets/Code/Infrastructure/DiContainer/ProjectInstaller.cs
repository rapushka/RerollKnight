using UnityEngine;
using Zenject;

namespace Code
{
	public class ProjectInstaller : MonoInstaller<ProjectInstaller>
	{
		[SerializeField] private LayoutService _layoutService;

		public override void InstallBindings()
		{
			Container.BindInstance(Contexts.sharedInstance).AsSingle();
			Container.Bind<SystemsFactory>().AsSingle();

			InstallServices();
		}

		private void InstallServices()
		{
			Container.Bind<IResourcesService>().To<ResourcesService>().AsSingle();
			Container.Bind<IAssetsService>().To<AssetsService>().AsSingle();
			Container.Bind<ILayoutService>().To<LayoutService>().FromScriptableObject(_layoutService).AsSingle();
			Container.Bind<IEntitiesManipulatorService>().To<EntitiesManipulatorService>().AsSingle();

			Container.Bind<GameStateMachine>().AsSingle();
			Container.Bind<ServicesMediator>().AsSingle();
		}
	}
}