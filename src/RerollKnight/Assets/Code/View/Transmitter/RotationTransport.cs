using Code.Component;
using UnityEngine;

namespace Code
{
	public class RotationTransport : GameTransportBase
	{
		[SerializeField] private Transform _transform;

		public override void Transfer()
		{
			Entity.Replace<Rotation, Quaternion>(_transform.rotation);
		}
	}
}