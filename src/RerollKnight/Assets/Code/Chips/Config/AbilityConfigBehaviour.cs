using Entitas.Generic;

namespace Code
{
	public class AbilityConfigBehaviour : EntityBehaviour<ChipsScope>
	{
		public ComponentBehaviourBase<ChipsScope>[] Components => ComponentBehaviours;

		public Entity<ChipsScope> AddAll(Entity<ChipsScope> entity)
		{
			foreach (var component in ComponentBehaviours)
				component.Add(ref entity);

			return entity;
		}
	}
}