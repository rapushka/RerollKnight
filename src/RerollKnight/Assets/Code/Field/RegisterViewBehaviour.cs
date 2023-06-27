using System;
using UnityEngine;

namespace Code
{
	public class RegisterViewBehaviour : GameComponentBehaviourBase
	{
		[SerializeField] private BaseView _view;

		public override void AddToEntity(ref GameEntity entity) => _view.Register(entity);

		public override void RemoveFromEntity(ref GameEntity entity)
			=> throw new NotImplementedException
			(
				"if you real need to remove view from listener"
				+ " – implement it in base view"
			);
	}
}