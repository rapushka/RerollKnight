using System.Linq;
using UnityEngine;

namespace Code
{
	public class ScreenSettings
	{
		public Vector2Int CurrentResolution
		{
			get => AsVector(Screen.currentResolution);
			set => Screen.SetResolution(value.x, value.y, IsFullscreen);
		}

		public bool IsFullscreen
		{
			get => Screen.fullScreen;
			set => Screen.fullScreen = value;
		}

		public Vector2Int[] AvailableResolutions => Screen.resolutions.Select(AsVector).ToArray();

		private static Vector2Int AsVector(Resolution resolution) => new(resolution.width, resolution.height);
	}
}