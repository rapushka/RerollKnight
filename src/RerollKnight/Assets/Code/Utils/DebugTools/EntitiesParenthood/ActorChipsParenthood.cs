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

			var ownerID = chip.Get<ForeignID>().Value;

			foreach (Transform actorBehaviour in ContextBehaviour.transform)
			{
				if (TryGetEntity(actorBehaviour.gameObject, out var actor)
				    && actor.Is<Actor>()
				    && actor.Get<ID>().Value == ownerID)
				{
					entityBehaviour.SetParent(actorBehaviour);
				}
			}
		}
#endif
	}
}