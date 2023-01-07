using UnityEngine;

namespace Code
{
	public abstract class EntitasAdapterBase : MonoBehaviour
	{
		private Feature _systems;

		protected Contexts Contexts => Contexts.sharedInstance;

		private void Start()
		{
			_systems = GetFeature();
			_systems.Initialize();
		}

		private void Update()
		{
			_systems.Execute();
			_systems.Cleanup();
		}

		private void OnDestroy() => _systems.TearDown();

		protected abstract Feature GetFeature();
	}
}