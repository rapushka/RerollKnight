using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class GameInstaller : MonoInstaller<GameInstaller>
	{
		[SerializeField] private BehavioursCollector _behavioursCollector;

		public override void InstallBindings()
		{
			Container.BindInstance(_behavioursCollector.Behaviours).AsSingle();

			Container.Bind<GameplayFeature>().AsSingle();
			Container.Bind<GameplayFeatureAdapter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

			Container.Rebind<SystemsFactory>().AsSingle();
			InstallGameplayStateMachine();

			Container.Bind<TurnsQueue>().AsSingle();
		}

		private void InstallGameplayStateMachine()
		{
			Container.BindInterfacesAndSelfTo<GameplayStateMachine>().AsSingle();
			Container.BindInterfacesAndSelfTo<StateChangeBus>().AsSingle();

			// Game preparations states
			Container.Bind<LoadAssetsGameplayState.StateFeature>().AsSingle();
			Container.Bind<InitializeGameplayState.StateFeature>().AsSingle();

			// Game loop states
			Container.Bind<ObservingGameplayState.StateFeature>().AsSingle();
			Container.Bind<ChipPickedGameplayState.StateFeature>().AsSingle();
			Container.Bind<WaitingGameplayState.StateFeature>().AsSingle();
			Container.Bind<TurnEndedGameplayState.StateFeature>().AsSingle();
			Container.Bind<OtherPlayerTurnGameplayState.StateFeature>().AsSingle();

#if DEBUG
			Container.BindInterfacesTo<GameplayStateDebugger>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
#endif
		}
	}
}