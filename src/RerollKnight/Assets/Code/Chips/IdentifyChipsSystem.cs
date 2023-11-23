using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	// todo: as i understand - it's useless now
	public sealed class IdentifyChipsSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<GameScope>> _chips;

		public IdentifyChipsSystem(Contexts contexts)
		{
			_chips = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Chip>());
		}

		public void Initialize()
		{
			foreach (var chip in _chips)
				chip.Add<ChipId, int>(chip.creationIndex);
		}
	}
}