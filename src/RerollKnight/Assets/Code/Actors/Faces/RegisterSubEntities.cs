using System.Collections.Generic;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class RegisterSubEntities<TScope> : ComponentBehaviourBase<TScope>
		where TScope : IScope
	{
		[SerializeField] private List<EntityBehaviour<TScope>> _behaviours;

		public override void Add(ref Entity<TScope> entity)
		{
			foreach (var entityBehaviour in _behaviours)
				Register(entityBehaviour);
		}

		private void Register(EntityBehaviour entityBehaviour)
		{
			entityBehaviour.CreateEntity(Contexts.Instance);
			entityBehaviour.Register();
		}
	}
}