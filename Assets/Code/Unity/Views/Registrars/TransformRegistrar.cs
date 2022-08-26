using UnityEngine;

namespace Code.Unity.Views.Registrars
{
	public class TransformRegistrar : MonoBehaviour, IViewComponentRegistrar
	{
		public void Register(GameEntity entity) 
			=> entity.AddTransform(GetComponent<Transform>());
	}
}