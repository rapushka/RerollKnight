using Code.Component;
using Entitas.Generic;
using UnityEditor;
using UnityEngine;
using EntityBehaviour = Entitas.VisualDebugging.Unity.EntityBehaviour;

namespace Code
{
	[InitializeOnLoad]
	public static class EntityClicker
	{
		static EntityClicker()
		{
			EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
		}

		private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
		{
			var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

			if (gameObject != null && gameObject.GetComponent<EntityBehaviour>() != null)
			{
				var buttonRect = new Rect
				(
					x: selectionRect.xMax - 100f,
					y: selectionRect.y,
					width: 60f,
					height: selectionRect.height
				);

				if (gameObject.GetComponent<EntityBehaviour>().entity is Entity<GameScope> entity)
				{
					if (GUI.Button(buttonRect, "Click"))
						entity.Is<Clicked>(true);
				}
			}
		}
	}
}