using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class AbilityOfChipComponentBehaviour : ComponentBehaviourBase<ChipsScope>
	{
		[SerializeField] private EntityBehaviour<GameScope> _behaviour;

		public override void Add(ref Entity<ChipsScope> entity)
			=> entity.Add<ForeignID, string>(EnsureID());

		private string EnsureID()
		{
			if (!_behaviour.Entity.Has<ID>())
				_behaviour.Entity.Identify();

			return _behaviour.Entity.Get<ID>().Value;
		}
	}
}