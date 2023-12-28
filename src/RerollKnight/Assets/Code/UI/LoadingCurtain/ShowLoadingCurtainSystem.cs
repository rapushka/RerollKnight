using Entitas;

namespace Code
{
	public class ShowLoadingCurtainSystem : IInitializeSystem
	{
		private readonly WindowsService _windows;

		public ShowLoadingCurtainSystem(WindowsService windows)
		{
			_windows = windows;
		}

		public void Initialize()
		{
			_windows.Show<LoadingCurtain>();
		}
	}
}