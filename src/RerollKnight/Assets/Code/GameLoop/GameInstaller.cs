using UnityEngine;
using Zenject;

namespace Code
{
	public class GameInstaller : MonoInstaller<GameInstaller>
	{
		[SerializeField] private EntityBehaviourBase[] _entityBehaviours;

		public override void InstallBindings()
		{
			Container.BindInstance(_entityBehaviours).AsSingle();
			Container.Bind<GameContextAdapter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

			Container.Bind<GameFeature>().AsSingle();
		}
	}
}