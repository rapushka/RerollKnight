using System.Linq;
using Entitas;
using Zenject;
using static GameMatcher;
using static ChipsMatcher;

namespace Code
{
	public sealed class MarkUnavailableByComponentsSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<ChipsEntity> _abilities;

		[Inject]
		public MarkUnavailableByComponentsSystem(Contexts contexts)
		{
			_targets = contexts.game.GetGroup(AvailableToPick);
			_abilities = contexts.chips.GetGroup(AllOf(TargetConstraints, State));
		}

		public void Execute()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Prepared))
			foreach (var target in _targets.GetEntities())
			{
				if (ability.targetConstraints.Value.Any((c) => !target.HasComponent(c.Value)))
					target.isAvailableToPick = false;
			}
		}
	}
}