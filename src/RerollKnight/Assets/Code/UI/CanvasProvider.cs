using UnityEngine;
using Zenject;

namespace Code
{
	public class CanvasProvider : IInitializable
	{
		private readonly IResourcesService _resources;
		private readonly IAssetsService _assets;
		private GameObject _canvas;

		public CanvasProvider(IResourcesService resources, IAssetsService assets)
		{
			_resources = resources;
			_assets = assets;
		}

		public Transform Canvas => _canvas.transform;

		public void Initialize()
		{
			_canvas = _assets.Instantiate(_resources.CanvasPrefab);
			Object.DontDestroyOnLoad(_canvas);
		}
	}
}