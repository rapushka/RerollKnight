using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class VisibleView : BaseListener<GameScope, Visible>
	{
		[SerializeField] private GameObject _target;

		public override void OnValueChanged(Entity<GameScope> entity, Visible component)
			=> _target.SetActive(component.Value);
	}
}