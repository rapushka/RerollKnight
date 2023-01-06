using UnityEngine;

namespace Code
{
	public class EntitasPlayerContextAdapter : MonoBehaviour
	{
		private PlayerFeature _systems;

		private void Start()
		{
			_systems = new PlayerFeature(Contexts.sharedInstance);
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