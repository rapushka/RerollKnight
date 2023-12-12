using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class GameInstaller : MonoInstaller<GameInstaller>
	{
		[SerializeField] private BehavioursCollector _behavioursCollector;
		[SerializeField] private HoldersProvider _holdersProvider;

		public override void InstallBindings()
		{
			Container.BindInstance(_behavioursCollector.Behaviours).AsSingle();
			Container.Bind<IHoldersProvider>().FromInstance(_holdersProvider).AsSingle();

			Container.Bind<GameplayFeature>().AsSingle();
			Container.Bind<GameplayFeatureAdapter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

			Container.Rebind<SystemsFactory>().AsSingle();
			InstallGameplayStateMachine();

			Container.Bind<TurnsQueue>().AsSingle();

			InstallFactories();
		}

		private void InstallGameplayStateMachine()
		{
			Container.BindInterfacesAndSelfTo<GameplayStateMachine>().AsSingle();

			Container.BindInterfacesAndSelfToAsSingle
			(
				// Game preparations
				typeof(LoadLevelGameplayState),
				typeof(InitializeGameplayState),

				// Game loop
				typeof(ObservingGameplayState),
				typeof(ChipPickedGameplayState),
				typeof(CastingAbilitiesGameplayState),
				typeof(TurnEndedGameplayState),
				typeof(RerollDicesGameplayState),
				typeof(PassTurnGameplayState),
				typeof(OtherPlayerTurnGameplayState),
				typeof(WanderingGameplayState),

				// Tools
				typeof(WaitAndThenToState)
			);

#if DEBUG
			Container.BindInterfacesTo<GameplayStateDebugger>()
			         .FromNewComponentOnNewGameObject().AsSingle()
			         .NonLazy();
#endif
		}

		private void InstallFactories()
		{
			// non-zenject factories
			Container.Bind<ActorsFactory>().AsSingle();
			Container.Bind<ChipsFactory>().AsSingle();
			Container.Bind<AbilitiesFactory>().AsSingle();
			Container.Bind<UiFactory>().AsSingle();
			Container.Bind<WallsFactory>().AsSingle();
			Container.Bind<RoomFactory>().AsSingle();
			Container.Bind<CellsSpawner>().AsSingle();
			Container.Bind<ActorsSpawner>().AsSingle();
			Container.Bind<WallsSpawner>().AsSingle();
		}
	}
}