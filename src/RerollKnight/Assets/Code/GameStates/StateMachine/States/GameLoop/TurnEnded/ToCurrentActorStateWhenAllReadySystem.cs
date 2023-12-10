using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public class ToCurrentActorStateWhenAllReadySystem : ToCurrentActorStateSystem, ICleanupSystem
	{
		public ToCurrentActorStateWhenAllReadySystem(Contexts contexts, IViewConfig viewConfig)
			: base(contexts, viewConfig)
			=> _entities = contexts.GetGroup(ScopeMatcher<InfrastructureScope>.Get<Ready>());

		private readonly IGroup<Entity<InfrastructureScope>> _entities;

		public void Cleanup()
		{
			// 'any' is useless here, just for clarity
			if (!_entities.Any() || _entities.All(IsReady))
				ChangeState();
		}

		private bool IsReady(Entity<InfrastructureScope> entity) => entity.Get<Ready>().Value;
	}
}