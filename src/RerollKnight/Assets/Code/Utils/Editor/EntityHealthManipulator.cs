using Code.Component;
using Entitas.Generic;
using UnityEditor;
using UnityEngine;
using EntityBehaviour = Entitas.VisualDebugging.Unity.EntityBehaviour;

namespace Code
{
	[InitializeOnLoad]
	public static class EntityHealthManipulator
	{
		static EntityHealthManipulator()
		{
			EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
		}

		private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
		{
			var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

			if (gameObject == null || gameObject.GetComponent<EntityBehaviour>() == null)
				return;

			var rectMinus = new Rect
			(
				x: selectionRect.xMax - 130f,
				y: selectionRect.y,
				width: 25f,
				height: selectionRect.height
			);
			var rectPlus = new Rect
			(
				x: selectionRect.xMax - 160f,
				y: selectionRect.y,
				width: 25f,
				height: selectionRect.height
			);

			if (gameObject.GetComponent<EntityBehaviour>().entity is Entity<GameScope> entity
			    && entity.Has<Health>())
			{
				if (GUI.Button(rectMinus, "-1"))
					entity.Replace<Health, int>(entity.Get<Health, int>() - 1);

				if (GUI.Button(rectPlus, "+1"))
					entity.Replace<Health, int>(entity.Get<Health, int>() + 1);
			}
		}
	}
}