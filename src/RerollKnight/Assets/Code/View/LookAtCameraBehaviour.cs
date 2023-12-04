using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class LookAtCameraBehaviour : ComponentBehaviourBase<GameScope>
	{
		public override void Add(ref Entity<GameScope> entity)
			=> entity.Add<LookAt, Transform>(Camera.main!.transform);
	}
}