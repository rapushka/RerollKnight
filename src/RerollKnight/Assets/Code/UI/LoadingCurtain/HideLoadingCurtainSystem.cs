using Entitas;

namespace Code
{
	public class HideLoadingCurtainSystem : ITearDownSystem
	{
		private readonly WindowsService _windows;

		public HideLoadingCurtainSystem(WindowsService windows)
		{
			_windows = windows;
		}

		public void TearDown()
		{
			(_windows.CurrentWindow as LoadingCurtain)?.FadeOut();
		}
	}
}