using UnityEngine;

namespace Code.Unity.Views.Registrars
{
	public class ArmsTransformRegistrar : MonoBehaviour, IViewComponentRegistrar
	{
		public void Register(GameEntity entity) 
			=> entity.AddArmsTransform(GetComponent<Transform>());
	}
}