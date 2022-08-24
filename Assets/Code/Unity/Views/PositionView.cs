using Entitas;
using UnityEngine;

namespace Code.Unity.Views
{
	public class PositionView : MonoBehaviour, IPositionListener, IEventListener
	{
		private GameEntity _entity;
		private Rigidbody _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		public void Register(IEntity entity)
		{
			_entity = (GameEntity)entity;
			_entity.AddPositionListener(this);

			if (_entity.hasPosition)
			{
				OnPosition(_entity, _entity.position);
			}
		}

		public void UnRegister()
		{
			_entity.RemovePositionListener(this);
		}

		public void OnPosition(GameEntity entity, Vector3 value)
		{
			_rigidbody.position = value;
		}
	}
}
