using System.Collections.Generic;
using Zenject;

namespace Code
{
	public class WindowsService
	{
		private readonly TypeDictionary<IWindow> _windows;

		private IWindow _currentWindow;

		[Inject]
		public WindowsService(IEnumerable<IWindow> windows)
		{
			_windows = TypeDictionary<IWindow>.FromIEnumerable(windows);

			foreach (var (_, window) in _windows)
				window.Hide();
		}

		public TWindow Show<TWindow>()
			where TWindow : IWindow
		{
			_currentWindow?.Hide();
			var newWindow = _windows.Get<TWindow>();
			_currentWindow = newWindow;
			_currentWindow.Show();

			return newWindow;
		}

		public void Hide<TWindow>()
			where TWindow : IWindow
		{
			if (_currentWindow is TWindow)
				HideCurrent();
		}

		public void HideCurrent()
		{
			_currentWindow.Hide();
			_currentWindow = null;
		}
	}
}