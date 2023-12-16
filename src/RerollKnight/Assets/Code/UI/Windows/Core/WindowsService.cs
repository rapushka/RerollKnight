using System.Collections.Generic;

namespace Code
{
	public class WindowsService
	{
		private readonly TypeDictionary<IWindow> _windows;

		private IWindow _currentWindow;

		public WindowsService(IEnumerable<IWindow> windows)
		{
			_windows = TypeDictionary<IWindow>.FromIEnumerable(windows);
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