using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class ActorChipsParenthood : EntitiesDebugParenthood<GameScope>
	{
#if DEBUG
		protected override void HandleEntity(Entity<GameScope> chip, Transform entityBehaviour)
		{
			if (!chip.Is<Chip>())
				return;

			var ownerID = chip.Get<BelongToActor>().Value;

			foreach (Transform other in ContextBehaviour.transform)
			{
				if (TryGetEntity(other.gameObject, out var otherEntity)
				    && otherEntity.Is<Actor>()
				    && otherEntity.Get<ID>().Value == ownerID)
				{
					entityBehaviour.SetParent(other);
				}
			}
		}
#endif
	}
}