using Code.Ecs.Features;
using UnityEngine;

namespace Code.Unity
{
	public class EcsLoader : MonoBehaviour
	{
		[SerializeField] private float _gravityScale;
		
		private CommonSystems _systems;

		private void Start()
		{
			var contexts = Contexts.sharedInstance;

			_systems = new CommonSystems(contexts, _gravityScale);
			
			_systems.Initialize();
		}

		private void Update() => _systems.Execute();

		private void LateUpdate() => _systems.Cleanup();

		private void OnDestroy() => _systems.TearDown();
	}
}
