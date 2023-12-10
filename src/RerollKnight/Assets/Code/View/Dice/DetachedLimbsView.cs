using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	public class DetachedLimbsView : BaseListener<GameScope, Detached>
	{
		[SerializeField] private GameObject _limbsRoot;

		public override void OnValueChanged(Entity<GameScope> entity, Detached component)
			=> _limbsRoot.SetActive(entity.Is<Detached>());
	}
}