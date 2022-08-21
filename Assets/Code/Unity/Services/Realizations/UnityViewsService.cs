using Code.Unity.Services.Interfaces;
using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Unity.Services.Realizations
{
	public class UnityViewsService : IViewsService
	{
		private Transform _viewRoot;

		public UnityViewsService()
		{
			_viewRoot = new GameObject(nameof(_viewRoot)).transform;
		}

		private static IResourcesService ResourcesService 
			=> Contexts.sharedInstance.services.resourcesService.Value;

		public GameObject BindViewToEntity(string viewPath, IEntity entity)
		{
			GameObject viewPrefab = ResourcesService.LoadResourceBy(viewPath);
			GameObject view = Object.Instantiate(viewPrefab, _viewRoot, false);

			return view.RegisterListeners(entity);
		}
	}
}
