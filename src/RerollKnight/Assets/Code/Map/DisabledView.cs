using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DisabledView : BaseListener<GameScope, Disabled>
	{
		[SerializeField] private GameObject _root;

		public override void OnValueChanged(Entity<GameScope> entity, Disabled component)
			=> _root.SetActive(!entity.Has<Disabled>());
	}
}