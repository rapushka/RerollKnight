using System.Collections.Generic;
using Zenject;

namespace Code
{
	public class WindowsService
	{
		private readonly IAssetsService _assetsService;
		private readonly CanvasProvider _canvasProvider;
		private readonly TypeDictionary<IWindow> _windows;

		private IWindow _currentWindow;

		[Inject]
		public WindowsService
			(IAssetsService assetsService, CanvasProvider canvasProvider, IEnumerable<IWindow> windowPrefabs)
		{
			_assetsService = assetsService;
			_canvasProvider = canvasProvider;
			_windows = InstantiateAll(windowPrefabs);
		}

		private TypeDictionary<IWindow> InstantiateAll(IEnumerable<IWindow> windowPrefabs)
		{
			var windows = new TypeDictionary<IWindow>();
			foreach (var windowPrefab in windowPrefabs)
			{
				var window = _assetsService.Instantiate((WindowBase)windowPrefab, _canvasProvider.Canvas);
				window.Close();

				windows.Add(window);
			}

			return windows;
		}

		public void Open<TWindow>()
			where TWindow : IWindow
		{
			_currentWindow?.Close();
			_currentWindow = _windows.Get<TWindow>();
			_currentWindow.Open();
		}

		public void CloseCurrent()
		{
			_currentWindow.Close();
			_currentWindow = null;
		}
	}
}