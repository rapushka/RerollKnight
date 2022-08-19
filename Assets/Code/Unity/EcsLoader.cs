using Code.Ecs.Features;
using Code.Unity.Services;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Unity
{
	public class EcsLoader : MonoBehaviour
	{
		[SerializeField] private ServicesCollection _services;
		
		private CommonSystems _systems;

		private void Start()
		{
			var contexts = Contexts.sharedInstance;

			SetUpServices();
			
			_systems = new CommonSystems(contexts, _services);
			
			_systems.Initialize();
		}

		private void SetUpServices()
		{
			_services.Time.DeltaTime = Time.deltaTime;
		}

		private void Update() => _systems.Execute();

		private void LateUpdate() => _systems.Cleanup();

		private void OnDestroy() => _systems.TearDown();
	}
}
