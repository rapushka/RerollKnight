using System;
using Code.Ecs.Features;
using Code.Ecs.Features.CommonSystems;
using Code.Ecs.Features.FixedUpdateSystems;
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
		private FixedUpdateSystems _fixedUpdateSystems;

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
				Scene = new UnitySceneService(),
			};

			_systems = new CommonSystems(contexts, services);
			_fixedUpdateSystems = new FixedUpdateSystems(contexts);

			_systems.Initialize();
			_fixedUpdateSystems.Initialize();
		}

		private void Update() => _systems.Execute();

		private void FixedUpdate() => _fixedUpdateSystems.Execute();

		private void LateUpdate()
		{
			_systems.Cleanup();
			_fixedUpdateSystems.Cleanup();
		}

		private void OnDestroy()
		{
			_systems.TearDown();
			_fixedUpdateSystems.TearDown();
		}
	}
}
