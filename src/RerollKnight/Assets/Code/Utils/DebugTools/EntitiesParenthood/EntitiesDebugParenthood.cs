using System.Collections;
using Entitas.Generic;
using Entitas.VisualDebugging.Unity;
using UnityEngine;
using EntityBehaviour = Entitas.VisualDebugging.Unity.EntityBehaviour;

namespace Code
{
	public abstract class EntitiesDebugParenthood<TScope> : MonoBehaviour
		where TScope : IScope
	{
#if DEBUG
		protected ContextObserverBehaviour ContextBehaviour;

		private IEnumerator Start()
		{
			DontDestroyOnLoad(gameObject);

			yield return null; // Ensure, that contexts were initialized

			var contexts = FindObjectsOfType<ContextObserverBehaviour>();

			foreach (var context in contexts)
			{
				// if (context.contextObserver.context is Context<Entity<GameScope>>)
				if (context.name.Contains(typeof(TScope).Name))
					ContextBehaviour = context;
			}

			OnStart();
		}

		private void Update()
		{
			if (ContextBehaviour is null)
				return;

			foreach (Transform child in ContextBehaviour.transform)
			{
				if (TryGetEntity(child.gameObject, out var entity) && entity.isEnabled)
					HandleEntity(entity, child);
			}
		}

		protected abstract void HandleEntity(Entity<TScope> entity, Transform entityBehaviour);

		protected virtual void OnStart() { }

		protected bool TryGetEntity(GameObject go, out Entity<TScope> entity)
		{
			var hasComponent = go.TryGetComponent<EntityBehaviour>(out var entityBehaviour);
			entity = hasComponent ? (Entity<TScope>)entityBehaviour.entity : null;
			return hasComponent;
		}
#endif
	}
}