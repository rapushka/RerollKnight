using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class RunAwayOnDefenceSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly ChipKinds _chipKinds;
		private readonly AvailabilityService _availability;
		private readonly IGroup<Entity<GameScope>> _chips;
		private readonly IGroup<Entity<GameScope>> _cells;

		[Inject]
		public RunAwayOnDefenceSystem(Contexts contexts, ChipKinds chipKinds, AvailabilityService availability)
		{
			_contexts = contexts;
			_chipKinds = chipKinds;
			_availability = availability;

			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<AvailableToPick>()));
			_cells = contexts.GetGroup(AllOf(Get<Cell>(), Get<DistanceToPlayer>()));
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		private EnemyStrategy EnemyStrategy => CurrentActor.Get<CurrentStrategy>().Value;

		private IEnumerable<Entity<GameScope>> MovementChips => _chips.Where(_chipKinds.IsMovementChip);

		public void Initialize()
		{
			if (EnemyStrategy is not EnemyStrategy.Defence)
				return;

			var strategy = MovementChips.Any(CanMoveAwayFromPlayer) ? EnemyStrategy.Waiting : EnemyStrategy.EndTurn;
			CurrentActor.Replace<CurrentStrategy, EnemyStrategy>(strategy);
		}

		private bool CanMoveAwayFromPlayer(Entity<GameScope> chip)
		{
			Entity<GameScope> farthestCell = null;

			foreach (var ability in chip.GetDependants<GameScope, ChipsScope>())
			{
				foreach (var cell in _cells)
				{
					_availability.EnsureAvailableByAll(cell, ability);

					if (!cell.Is<AvailableToPick>())
						continue;

					if (farthestCell is null
					    || farthestCell.Get<DistanceToPlayer>().Value < cell.Get<DistanceToPlayer>().Value)
					{
						farthestCell = cell;
					}
				}

				if (farthestCell is not null)
				{
					chip.Pick();
					farthestCell.Pick();
					return true;
				}
			}

			return false;
		}
	}
}