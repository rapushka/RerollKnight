using Entitas;

namespace Code
{
	public class HideLoadingCurtainImmediatelySystem : ITearDownSystem
	{
		private readonly WindowsService _windows;

		public HideLoadingCurtainImmediatelySystem(WindowsService windows)
		{
			_windows = windows;
		}

		public void TearDown()
		{
			(_windows.CurrentWindow as LoadingCurtain)?.HideImmediately();
		}
	}
}