using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Unity.Views.Registrars
{
	public class PlayerSpawnPositionRegistrar : MonoBehaviour, IViewComponentRegistrar
	{
		private static IResourcesService Resources => Contexts.sharedInstance.services.resourcesService.Value;

		public void Register(GameEntity entity)
		{
			entity.AddSpawnPosition(Resources.PlayerSpawnPoint.position);
		}
	}
}