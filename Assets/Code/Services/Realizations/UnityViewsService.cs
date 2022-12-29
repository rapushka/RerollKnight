using Code.Services.Interfaces;
using Code.Unity.Views.ViewController;
using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Services.Realizations
{
	public class UnityViewsService : IViewsService
	{
		private readonly Transform _viewRoot;

		public UnityViewsService() => _viewRoot = new GameObject("View Root").transform;

		private static IResourcesService ResourcesService => Contexts.sharedInstance.services.resourcesService.Value;

		public GameObject LoadViewForEntity(string viewPath, IEntity entity)
			=> LoadViewForEntity(ResourcesService.LoadResourceBy(viewPath), entity);

		public GameObject LoadViewForEntity(GameObject viewPrefab, IEntity entity)
			=> Object.Instantiate(viewPrefab, _viewRoot, worldPositionStays: true)
			         .CreateController<UnityViewController>(entity)
			         .RegisterListeners(entity);
	}
}