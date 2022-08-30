using UnityEngine;

namespace Code.Unity.Views.Registrars
{
	public class WeaponTransformRegistrar : MonoBehaviour, IViewComponentRegistrar
	{
		public void Register(GameEntity entity)
			=> entity.AddTransform(GetComponent<Transform>());
	}
}