using UnityEngine;

namespace Code
{
	public static class AudioExtensions
	{
		public static float AsAudioVolume(this float @this)
			=> @this.Lerp(Constants.Audio.MinVolume, Constants.Audio.MaxVolume);

		public static float Lerp(this float @this, float min, float max)
			=> Mathf.Lerp(a: min, b: max, t: @this);
	}
}