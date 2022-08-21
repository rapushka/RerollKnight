using UnityEngine;

namespace Code.Unity.Views.Registrars
{
	public class RigidbodyRegistrar : MonoBehaviour, IViewComponentRegistrar
	{
		public void Register(GameEntity entity)
			=> entity.AddRigidbody(GetComponent<Rigidbody>());
	}
}
