using System;
using Entitas;
using static ChipsMatcher;
using static GameMatcher;

namespace Code
{
	public sealed class ValidateMaxCountOfTargetsOverflowSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<ChipsEntity> _abilities;

		public ValidateMaxCountOfTargetsOverflowSystem(Contexts contexts)
		{
			_targets = contexts.game.GetGroup(PickedTarget);
			_abilities = contexts.chips.GetGroup(AllOf(PreparedAbility, MaxCountOfTargets));
		}

		private int TargetsCount => _targets.count;

		public void Execute()
		{
			if (_abilities.Any((a) => TargetsCount > a.maxCountOfTargets.Value))
			{
				throw new InvalidOperationException("Too many targets for the ability");
			}
		}
	}
}