using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class PlayChipClickSoundSystem : IExecuteSystem
	{
		private readonly AudioService _audio;
		private readonly IGroup<Entity<GameScope>> _entities;

		[Inject]
		public PlayChipClickSoundSystem(Contexts contexts, AudioService audio)
		{
			_audio = audio;
			_entities = contexts.GetGroup(AllOf(Get<Chip>(), Get<Clicked>()));
		}

		public void Execute()
		{
			foreach (var _ in _entities)
				_audio.Play(Sound.ChipClick);
		}
	}
}