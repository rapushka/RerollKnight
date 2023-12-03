using Code.Component;
using Entitas.Generic;
using Entitas.VisualDebugging.Unity;
using UnityEngine;

namespace Code
{
	public class DestroyedView : BaseListener<GameScope, Destroyed>
	{
		[SerializeField] private GameObject _root;

		public override void OnValueChanged(Entity<GameScope> entity, Destroyed component)
		{
			// _root.Unlink();
			_root.DestroyGameObject();
		}
	}
}