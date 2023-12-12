using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class HideAllChipsSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<GameScope>> _chips;

		[Inject]
		public HideAllChipsSystem(Contexts contexts)
			=> _chips = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Chip>());

		public void Initialize()
		{
			foreach (var chip in _chips)
			{
				chip.Is<AvailableToPick>(false);
				chip.Is<Visible>(false);
			}
		}
	}
}