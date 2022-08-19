using Code.Unity.Services.Interfaces;
using Code.Unity.Views;

namespace Code.Unity.Services.Realizations
{
	public class UnityViewsService : IViewsService
	{
		private readonly IResourcesService _resources;
		private RigidbodyView _rigidbodyCash;

		public UnityViewsService(IResourcesService resources)
		{
			_resources = Contexts.sharedInstance.game.resourcesService.Value;
		}

		public RigidbodyView Rigidbody => _rigidbodyCash
			??= _resources.PlayerPrefab.GetComponent<RigidbodyView>();
	}
}
