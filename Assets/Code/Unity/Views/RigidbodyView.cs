using UnityEngine;

namespace Code.Unity.Views
{
	public class RigidbodyView : MonoBehaviour, IRigidbodyListener
	{
		public void Construct(GameEntity entity)
		{
			entity.AddRigidbodyListener(this);
		}
		
		public void OnRigidbody(GameEntity entity, Rigidbody value)
		{
			transform.position = value.position;
		}
	}
}
