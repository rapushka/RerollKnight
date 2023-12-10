using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DiceBodyBehaviour : ComponentBehaviourBase<GameScope>
	{
		[SerializeField] private EntityBehaviour<GameScope> _behaviour;

		public override void Add(ref Entity<GameScope> entity)
			=> entity.Add<DiceBody, Entity<GameScope>>(_behaviour.Entity);
	}
}