using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public abstract class RegisterViewBehaviour<TScope> : ComponentBehaviourBase<TScope>
		where TScope : IScope
	{
		[SerializeField] private BaseListener<TScope> _listener;

		public override void Add(ref Entity<TScope> entity)
			=> entity.Register(_listener);
	}
}