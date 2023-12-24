using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class MoveToPlayerSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly ChipKinds _chipKinds;
		private readonly AvailabilityService _availability;
		private readonly IGroup<Entity<GameScope>> _chips;
		private readonly IGroup<Entity<GameScope>> _cells;

		[Inject]
		public MoveToPlayerSystem(Contexts contexts, ChipKinds chipKinds, AvailabilityService availability)
		{
			_contexts = contexts;
			_chipKinds = chipKinds;
			_availability = availability;

			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<AvailableToPick>()));
			_cells = contexts.GetGroup(AllOf(Get<Cell>(), Get<DistanceToPlayer>()));
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			if (CurrentActor.Get<CurrentStrategy>().Value is not EnemyStrategy.MoveToPlayer)
				return;

			foreach (var chip in _chips)
			{
				if (!_chipKinds.IsMovementChip(chip))
					continue;

				var moved = MoveToPlayer(chip);

				if (moved)
					return;
			}

			CurrentActor.Replace<CurrentStrategy, EnemyStrategy>(EnemyStrategy.EndTurn);
		}

		private bool MoveToPlayer(Entity<GameScope> chip)
		{
			// _availability.MarkAllTargetsAvailable();
			Entity<GameScope> closerCell = null;

			foreach (var ability in chip.GetDependants<GameScope, ChipsScope>())
			{
				foreach (var cell in _cells)
				{
					_availability.EnsureAvailableByAll(cell, ability);

					if (!cell.Is<AvailableToPick>())
						continue;

					if (closerCell is null
					    || closerCell.Get<DistanceToPlayer>().Value > cell.Get<DistanceToPlayer>().Value)
					{
						closerCell = cell;
					}
				}

				if (closerCell is null)
					continue;

				chip.Pick();
				closerCell.Pick();
				return true;
			}

			return false;
		}
	}
}