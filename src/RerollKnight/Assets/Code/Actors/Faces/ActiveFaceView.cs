using System.Linq;
using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	// will be on player
	public class ActiveFaceView : BaseListener<GameScope>
	{
		[SerializeField] private Transform _transform;

		public override void Register(Entity<GameScope> entity)
		{
			var faces = entity.GetDependants().Where((e) => e.Has<Face>());

			var count = faces.Count();

			var randomNumber = RandomService.Instance.Range(0, count);
		}
	}
}