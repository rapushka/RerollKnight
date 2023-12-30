using Entitas;

namespace Code
{
	public class PlayRerollSoundSystem : IInitializeSystem, ITearDownSystem
	{
		private readonly AudioService _audio;

		public PlayRerollSoundSystem(AudioService audio)
		{
			_audio = audio;
		}

		public void Initialize()
		{
			_audio.Play(Sound.DicesThrow);
		}

		public void TearDown()
		{
			_audio.Play(Sound.DicesLand);
		}
	}
}