using Code.Ecs.Features;
using Code.Unity.Services;
using Code.Unity.Services.Realizations;
using UnityEngine;

namespace Code.Unity
{
	public class EntitasLoader : MonoBehaviour
	{
		[SerializeField] private SerializableBalanceService serializableBalanceService;
		
		private ServicesCollection _services;
		private CommonSystems _systems;
		private Contexts _contexts;

		private void Start()
		{
			_contexts = Contexts.sharedInstance;

			_services = new ServicesCollection
			{
				Balance = serializableBalanceService,
				Time = new UnityTimeService(),
			};

			_systems = new CommonSystems(_contexts, _services);
			
			_systems.Initialize();
		}

		private void Update()
		{
			_systems.Execute();
		}

		private void LateUpdate() => _systems.Cleanup();

		private void OnDestroy() => _systems.TearDown();
	}
}
