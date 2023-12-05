using Code.Component;
using UnityEngine;

namespace Code
{
	public class PositionTransport : GameTransportBase
	{
		[SerializeField] private Transform _transform;

		public override void Transfer()
		{
			if (Entity.GetOrDefault<Position>()?.Value != _transform.position)
				Entity.Replace<Position, Vector3>(_transform.position);
		}
	}
}