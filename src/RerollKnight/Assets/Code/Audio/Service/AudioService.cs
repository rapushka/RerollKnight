using UnityEngine;

namespace Code
{
	public class AudioService
	{
		private readonly SoundsCollection _sounds;
		private readonly AudioSourcesProvider _sources;

		public AudioService(SoundsCollection sounds, AudioSourcesProvider sources)
		{
			_sounds = sounds;
			_sources = sources;
		}

		public void Play(Sound sound, float volume = 1f)
		{
			Debug.Log($"sound = {sound}");
			_sources.SoundsSource.PlayOneShot(_sounds[sound], volume);
		}
	}
}