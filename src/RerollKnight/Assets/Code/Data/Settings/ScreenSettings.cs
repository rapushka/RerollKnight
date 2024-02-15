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

		public Vector2Int[] AvailableResolutions
		{
			get
			{
#if UNITY_EDITOR || UNITY_STANDALONE
				return Screen.resolutions.Select(AsVector).ToArray();
#elif UNITY_ANDROID || UNITY_IOS
				return Screen.resolutions.Select(TurnToLandscape).Select(AsVector).ToArray();

				Resolution TurnToLandscape(Resolution r)
					=> new() { width = r.height, height = r.width, refreshRateRatio = r.refreshRateRatio };
#endif
			}
		}

		private static Vector2Int AsVector(Resolution resolution) => new(resolution.width, resolution.height);
	}
}