using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class TryAttackSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly AvailabilityService _availability;
		private readonly ChipKinds _chipKinds;

		private readonly IGroup<Entity<GameScope>> _chips;
		private readonly IGroup<Entity<GameScope>> _players;

		[Inject]
		public TryAttackSystem(Contexts contexts, AvailabilityService availability, ChipKinds chipKinds)
		{
			_contexts = contexts;
			_availability = availability;
			_chipKinds = chipKinds;

			_chips = contexts.GetGroup(AllOf(Get<Chip>(), Get<AvailableToPick>()));
			_players = contexts.GetGroup(Get<Player>());
		}

		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			if (CurrentActor.Get<CurrentStrategy>().Value is not EnemyStrategy.Attack)
				return;

			foreach (var player in _players)
			{
				var isAttacked = TryAttackWithEachChip(player);
				if (isAttacked)
				{
					ChangeStrategy(EnemyStrategy.Waiting);
					return;
				}
			}

			ChangeStrategy(EnemyStrategy.MoveToPlayer);
		}

		private void ChangeStrategy(EnemyStrategy strategy)
			=> CurrentActor.Replace<CurrentStrategy, EnemyStrategy>(strategy);

		private bool TryAttackWithEachChip(Entity<GameScope> player)
		{
			foreach (var chip in _chips.Where(_chipKinds.IsAttackingChip))
			foreach (var ability in chip.GetDependants<GameScope, ChipsScope>())
			{
				_availability.EnsureAvailableByAll(player, ability);

				if (player.Is<AvailableToPick>())
				{
					chip.Pick();
					player.Pick();
					return true;
				}
			}

			return false;
		}
	}
}