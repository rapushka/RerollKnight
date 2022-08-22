using UnityEngine;

namespace Code.Unity.Views.Registrars
{
	public class LegsPointTransformRegistrar : MonoBehaviour, IViewComponentRegistrar
	{
		public void Register(GameEntity entity) 
			=> entity.AddLegsPointTransform(GetComponent<Transform>());
	}
}