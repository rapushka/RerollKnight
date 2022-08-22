using Code.Ecs.Features;
using Code.Services;
using Code.Services.Realizations;
using UnityEngine;

namespace Code.Unity
{
	public class EntitasLoader : MonoBehaviour
	{
		[SerializeField] private SerializableBalanceService _balance;
		[SerializeField] private SerializableResourcesService _resources;

		private CommonSystems _systems;

		private void Start()
		{
			var contexts = Contexts.sharedInstance;

			ServicesCollection services = new()
			{
				Balance = _balance,
				Resources = _resources,
				Time = new UnityTimeService(),
				Views = new UnityViewsService(),
				Input = new UnityNewInputService(),
				Physics = new UnityPhysicsService(),
				Identifier = new IntIdentifierService(),
			};

			_systems = new CommonSystems(contexts, services);

			_systems.Initialize();
		}

		private void Update() => _systems.Execute();

		private void LateUpdate() => _systems.Cleanup();

		private void OnDestroy() => _systems.TearDown();
	}
}
