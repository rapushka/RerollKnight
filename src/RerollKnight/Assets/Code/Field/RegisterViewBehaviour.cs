using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class RegisterViewBehaviour : ComponentBehaviourBase<GameScope>
	{
		[SerializeField] private GameObject _view;

		public override void Add(ref Entity<GameScope> entity)
			// TODO: serialize field BaseListener<GameScope>
			=> entity.Register(_view.GetComponent<IRegistrableListener<GameScope>>());
	}
}