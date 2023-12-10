using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;
using UnityEngine;
using EntityBehaviour = Entitas.VisualDebugging.Unity.EntityBehaviour;

namespace Code
{
	public class ForeignIDParenthood : EntitiesDebugParenthood<GameScope>
	{
#if DEBUG
		private IEnumerable<EntityBehaviour> ChildrenEntities
			=> ContextBehaviour.GetComponentsInChildren<EntityBehaviour>();

		protected override void HandleEntity(Entity<GameScope> entity, Transform entityBehaviour)
		{
			if (!entity.Has<ForeignID>())
				return;

			var ownerID = entity.Get<ForeignID>().Value;

			foreach (var ownerBehaviour in ChildrenEntities)
			{
				var owner = (Entity<GameScope>)ownerBehaviour.entity;

				if (owner.EnsureID() == ownerID)
					entityBehaviour.SetParent(ownerBehaviour.transform);
			}
		}
#endif
	}
}