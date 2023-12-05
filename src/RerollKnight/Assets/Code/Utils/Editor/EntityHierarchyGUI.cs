using Code.Component;
using Entitas.Generic;
using UnityEditor;
using UnityEngine;

namespace Code
{
	[InitializeOnLoad]
	public static class EntityHierarchyGUI
	{
		static EntityHierarchyGUI()
		{
			EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
		}

		private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
		{
			if (!HierarchyHelper.TryGetEntity(instanceID, out var entity))
				return;

			var rect = HierarchyHelper.ButtonRect(selectionRect, width: 60f, fromRight: 100f);
			if (GUI.Button(rect, "Click"))
				entity.Is<Clicked>(true);

			if (entity.Has<Health>() && entity.Has<ID>())
			{
				rect = HierarchyHelper.ButtonRect(selectionRect, width: 25f, fromRight: 160f);
				if (GUI.Button(rect, "-1"))
				{
					ChangeHeal(entity, -1);
				}

				rect = HierarchyHelper.ButtonRect(selectionRect, width: 25f, fromRight: 130f);
				if (GUI.Button(rect, "+1"))
					ChangeHeal(entity, +1);
			}
		}

		private static void ChangeHeal(Entity<GameScope> entity, int value)
		{
			Contexts.Instance.Get<RequestScope>().CreateEntity()
			        .Add<ChangeHealth, int>(value)
			        .Add<ForeignID, string>(entity.Get<ID>().Value)
				;
		}
	}
}