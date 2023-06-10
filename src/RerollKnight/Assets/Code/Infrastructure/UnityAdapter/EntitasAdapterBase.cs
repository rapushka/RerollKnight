using JetBrains.Annotations;
using UnityEngine;

namespace Code
{
	public abstract class EntitasAdapterBase : MonoBehaviour
	{
		[CanBeNull] private Feature _fixedUpdateSystems;
		private Feature _systems;

		protected static Contexts Contexts => Contexts.sharedInstance;

		protected abstract Feature Feature { get; }

		protected virtual Feature FixedUpdateFeature => null;

		private void Start()
		{
			_systems = Feature;
			_fixedUpdateSystems = FixedUpdateFeature;

			_systems.Initialize();
			_fixedUpdateSystems?.Initialize();
		}

		private void Update()
		{
			_systems.Execute();
			_systems.Cleanup();
		}

		private void FixedUpdate()
		{
			_fixedUpdateSystems?.Execute();
			_fixedUpdateSystems?.Cleanup();
		}

		private void OnDestroy()
		{
			_systems.TearDown();
			_fixedUpdateSystems?.TearDown();
		}
	}
}