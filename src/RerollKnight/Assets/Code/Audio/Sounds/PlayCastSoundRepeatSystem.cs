using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class PlayCastSoundRepeatSystem : IExecuteSystem, ITearDownSystem
	{
		private readonly AudioService _audio;
		private readonly ITimeService _time;
		private readonly IGroup<Entity<GameScope>> _entities;

		public PlayCastSoundRepeatSystem(Contexts contexts, AudioService audio, ITimeService time)
		{
			_audio = audio;
			_time = time;
			_entities = contexts.GetGroup(AllOf(Get<PickedChip>(), Get<CastSound>(), Get<RepeatSound>()));
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				if (!e.Has<TimeToNextRepeat>())
					ResetTimer(e);

				e.Get<TimeToNextRepeat>().Value -= _time.DeltaTime;

				if (e.Get<TimeToNextRepeat>().Value <= 0f)
				{
					e.Remove<TimeToNextRepeat>();
					_audio.Play(e.Get<CastSound>().Value);
				}
			}
		}

		public void TearDown()
		{
			foreach (var e in _entities)
				e.RemoveSafety<TimeToNextRepeat>();
		}

		private static void ResetTimer(Entity<GameScope> e)
		{
			e.Replace<TimeToNextRepeat, float>(e.Get<RepeatSound>().Value);
		}
	}
}