namespace Code
{
	public sealed class AudioFeature : InjectableFeature
	{
		public AudioFeature(SystemsFactory factory)
			: base(nameof(AudioFeature), factory)
		{
			Add<PlayChipClickSoundSystem>();
		}
	}
}