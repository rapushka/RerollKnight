using System;
using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	/// <summary> temporary (i hope) </summary>
	public class DiceRotationView : BaseListener<GameScope, ActiveFace>
	{
		[SerializeField] private EntityBehaviour<GameScope> _bodyBehaviour;
		[SerializeField] private List<RotationEntry> _rotations;

		public override void OnValueChanged(Entity<GameScope> entity, ActiveFace component)
		{
			var rotation = _rotations.SingleOrDefault((r) => r.Number == component.Value)?.Quaternion;
			if (rotation is not null)
			{
				_bodyBehaviour.Entity.Replace<DestinationRotation, Quaternion>(Quaternion.Euler(rotation.Value));
				// _bodyTransform.rotation = Quaternion.Euler(rotation.Value);
			}
		}

		[Serializable]
		public class RotationEntry
		{
			public int Number;
			public Vector3 Quaternion;
		}
	}
}