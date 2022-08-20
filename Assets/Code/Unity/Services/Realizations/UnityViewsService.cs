using Code.Unity.Services.Interfaces;
using Code.Unity.Views;

namespace Code.Unity.Services.Realizations
{
	public class UnityViewsService : IViewsService
	{
		private readonly IResourcesService _resources;
		private PositionView _positionCash;

		public UnityViewsService(IResourcesService resources)
		{
			_resources = resources;
		}

		public PositionView PlayerPosition => _positionCash
			??= _resources.PlayerPrefab.GetComponent<PositionView>();
	}
}
