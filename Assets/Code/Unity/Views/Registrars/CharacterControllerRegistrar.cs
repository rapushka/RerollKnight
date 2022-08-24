using UnityEngine;

namespace Code.Unity.Views.Registrars
{
	public class CharacterControllerRegistrar : MonoBehaviour, IViewComponentRegistrar
	{
		public void Register(GameEntity entity) => entity.AddCharacterController(GetComponent<CharacterController>());
	}
}