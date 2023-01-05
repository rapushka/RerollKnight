using UnityEngine;

namespace Code
{
	public class EntitasAdapter : MonoBehaviour
	{
		private GameFeature _systems;

		private void Start()
		{
			_systems = new GameFeature(Contexts.sharedInstance);
			_systems.Initialize();
		}

		private void Update()
		{
			_systems.Execute();
			_systems.Cleanup();
		}

		private void OnDestroy() => _systems.TearDown();
	}
}