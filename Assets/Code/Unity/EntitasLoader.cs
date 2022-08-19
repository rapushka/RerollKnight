using Code.Ecs.Features;
using Code.Unity.Services;
using Code.Unity.Services.Realizations;
using UnityEngine;

namespace Code.Unity
{
	public class EntitasLoader : MonoBehaviour
	{
		[SerializeField] private SerializableBalanceService serializableBalanceService;

		private CommonSystems _systems;

		private void Start()
		{
			var contexts = Contexts.sharedInstance;

			ServicesCollection services = new()
			{
				Balance = serializableBalanceService,
				Time = new UnityTimeService(),
			};

			_systems = new CommonSystems(contexts, services);

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
