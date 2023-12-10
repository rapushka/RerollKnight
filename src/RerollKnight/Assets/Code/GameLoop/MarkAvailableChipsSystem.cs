using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code
{
	public sealed class MarkAvailableChipsSystem : ITearDownSystem
	{
		private readonly IGroup<GameEntity> _chips;

		[Inject]
		public MarkAvailableChipsSystem(Contexts contexts)
			=> _chips = contexts.GetGroup(Get<Chip>());

		public void TearDown()
		{
			foreach (var chip in _chips)
			{
				var face = chip.GetOwner();
				var actor = face.GetOwner();

				var isAvailable = face.IsActiveFace() && actor.Is<CurrentActor>();
				chip.Is<AvailableToPick>(isAvailable);
				chip.Is<Visible>(isAvailable);
			}
		}
	}
}