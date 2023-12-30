using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class PlayCastSoundOneShotSystem : ITearDownSystem
	{
		private readonly Contexts _contexts;
		private readonly AudioService _audio;

		public PlayCastSoundOneShotSystem(Contexts contexts, AudioService audio)
		{
			_contexts = contexts;
			_audio = audio;
		}

		private Entity<GameScope> PickedChip => Unique.GetEntity<PickedChip>();

		private UniqueComponentsContainer<GameScope> Unique => _contexts.Get<GameScope>().Unique;

		public void TearDown()
		{
			if (PickedChip.Has<CastSound>() && !PickedChip.Has<RepeatSound>())
				PlayOneShot();
		}

		private void PlayOneShot() => _audio.Play(PickedChip.Get<CastSound>().Value);
	}
}