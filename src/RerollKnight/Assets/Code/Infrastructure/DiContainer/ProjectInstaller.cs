using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class ProjectInstaller : MonoInstaller<ProjectInstaller>
	{
		[SerializeField] private LayoutService _layoutService;

		public override void InstallBindings()
		{
			Container.BindInstance(Contexts.Instance).AsSingle();
			Container.Bind<ContextsInitializer>().AsSingle().NonLazy();
			Container.Bind<SystemsFactory>().AsSingle();

			InstallServices();
			InstallGameStateMachine();
		}

		private void InstallServices()
		{
			Container.Bind<IResourcesService>().To<ResourcesService>().AsSingle();
			Container.Bind<IAssetsService>().To<AssetsService>().AsSingle();
			Container.Bind<ILayoutService>().To<LayoutService>().FromScriptableObject(_layoutService).AsSingle();
			Container.Bind<IEntitiesManipulatorService>().To<EntitiesManipulatorService>().AsSingle();

			Container.Bind<ServicesMediator>().AsSingle();
		}

		private void InstallGameStateMachine()
		{
			Container.Bind<GameStateMachine>().AsSingle();

			Container.Bind<ObservingGameState.StateFeature>().AsSingle();
			Container.Bind<ChipPickedGameState.StateFeature>().AsSingle();
			Container.Bind<TurnEndedGameState.StateFeature>().AsSingle();
			Container.Bind<WaitingGameState.StateFeature>().AsSingle();
		}
	}
}