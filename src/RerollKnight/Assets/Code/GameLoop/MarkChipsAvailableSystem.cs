using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;
using GameEntity = Entitas.Generic.Entity<Code.GameScope>;

namespace Code
{
	public sealed class MarkChipsAvailableSystem : ITearDownSystem
	{
		private readonly IGroup<GameEntity> _chips;

		[Inject]
		public MarkChipsAvailableSystem(Contexts contexts)
			=> _chips = contexts.GetGroup(Get<Chip>());

		public void TearDown()
		{
			foreach (var chip in _chips)
			{
				var face = chip.GetOwner();
				var actor = face.GetOwner();

				chip.Is<AvailableToPick>(face.IsActiveFace() && actor.Is<CurrentActor>());
			}
		}
	}
}