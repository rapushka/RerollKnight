using UnityEngine;

namespace Code
{
	public class ScreenSettings
	{
		public Resolution CurrentResolution
		{
			get => Screen.currentResolution;
			set => Screen.SetResolution(value.width, value.height, IsFullscreen);
		}

		public bool IsFullscreen
		{
			get => Screen.fullScreen;
			set => Screen.fullScreen = value;
		}

		public Resolution[] AvailableResolutions => Screen.resolutions;
	}
}