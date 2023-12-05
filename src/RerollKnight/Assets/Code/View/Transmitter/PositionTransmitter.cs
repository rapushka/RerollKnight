using Code.Component;
using UnityEngine;

namespace Code
{
	public class PositionTransmitter : GameTransmitterBase
	{
		[SerializeField] private Transform _transform;

		public override void Transfer()
		{
			Entity.Replace<Position, Vector3>(_transform.position);
		}
	}
}