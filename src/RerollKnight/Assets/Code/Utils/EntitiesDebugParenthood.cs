using Code.Component;
using Entitas.Generic;
using Entitas.VisualDebugging.Unity;
using UnityEngine;
using EntityBehaviour = Entitas.VisualDebugging.Unity.EntityBehaviour;

namespace Code
{
	public class EntitiesDebugParenthood : MonoBehaviour
	{
#if DEBUG
		private ContextObserverBehaviour _context;
		private GameObject _cellsRoot;

		private void Start()
		{
			DontDestroyOnLoad(gameObject);

			var contexts = FindObjectsOfType<ContextObserverBehaviour>();

			foreach (var context in contexts)
			{
				// if (context.contextObserver.context is Context<Entity<GameScope>>)
				if (context.name.Contains(nameof(GameScope)))
				{
					_context = context;
					_cellsRoot = new GameObject("_Cells Root") { transform = { parent = _context.transform } };
				}
			}
		}

		private void Update()
		{
			foreach (Transform child in _context.transform)
			{
				if (!child.gameObject.TryGetComponent<EntityBehaviour>(out var entityBehaviour))
					continue;

				var gameEntity = (Entity<GameScope>)entityBehaviour.entity;

				if (gameEntity.Is<Cell>())
					child.SetParent(_cellsRoot.transform);
			}
		}
#endif
	}
}