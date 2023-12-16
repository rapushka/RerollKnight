using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class ProjectInstaller : MonoInstaller<ProjectInstaller>
	{
		[SerializeField] private ViewConfig _viewConfig;
		[SerializeField] private ChipsConfig _chipsConfig;
		[SerializeField] private GenerationConfig _generationConfig;
		[SerializeField] private WindowBase[] _windows;

		public override void InstallBindings()
		{
			var canvas = Instantiate(Resources.Load<Canvas>("UI/Canvas"), transform);

			Container.BindInterfacesTo<Starter>().AsSingle();

			Container.Bind<Game>().AsSingle();

			Container.BindInstance(Contexts.Instance).AsSingle();
			Container.Bind<ContextsInitializer>().AsSingle().NonLazy();
			Container.Bind<SystemsFactory>().AsSingle();
			Container.Bind<Query>().AsSingle();

#if Develop
			Container.Bind<FpsCounter>()
			         .FromNewComponentOnNewGameObject()
			         .UnderTransform(transform)
			         .AsSingle()
			         .NonLazy();
#endif

			InstallServices();

			foreach (var window in _windows)
				Container.BindInterfacesAndSelfTo(window.GetType())
				         .FromComponentInNewPrefab(window)
				         .UnderTransform(canvas.transform)
				         .AsSingle();
		}

		private void InstallServices()
		{
			Container.Bind<IResourcesService>().To<ResourcesService>().AsSingle();
			Container.Bind<IAssetsService>().To<AssetsService>().AsSingle();
			Container.Bind<IViewConfig>().To<ViewConfig>().FromScriptableObject(_viewConfig).AsSingle();
			Container.Bind<ITimeService>().To<TimeService>().AsSingle();
			Container.Bind<ChipsConfig>().FromScriptableObject(_chipsConfig).AsSingle();
			Container.Bind<GenerationConfig>().FromScriptableObject(_generationConfig).AsSingle();

			Container.Bind<RandomService>().FromInstance(RandomService.Instance).AsSingle();

			Container.Bind<ServicesMediator>().AsSingle();
			Container.Bind<UiMediator>().AsSingle();

			Container.Bind<ISceneTransfer>().To<SceneTransfer>().AsSingle();
			Container.Bind<WindowsService>().AsSingle();

			Container.Bind<IStorageService>().To<PlayerPrefsStorage>().AsSingle();

			Container.Bind<ILocalizationService>().To<LocalizationService>().AsSingle();
			Container.Bind<ScreenSettings>().AsSingle();
		}
	}
}