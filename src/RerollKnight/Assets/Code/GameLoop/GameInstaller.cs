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
			Container.Bind<GameFeature>().AsSingle();

			Container.Bind<GameFeatureAdapter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

			Container.Rebind<SystemsFactory>().AsSingle();
			InstallGameStateMachine();
		}

		private void InstallGameStateMachine()
		{
			Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
			Container.BindInterfacesAndSelfTo<StateChangeBus>().AsSingle();

			Container.Bind<ObservingGameState.StateFeature>().AsSingle();
			Container.Bind<ChipPickedGameState.StateFeature>().AsSingle();
			Container.Bind<TurnEndedGameState.StateFeature>().AsSingle();
			Container.Bind<WaitingGameState.StateFeature>().AsSingle();
		}
	}
}