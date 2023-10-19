using Entitas;
using static ChipsMatcher;
using static GameMatcher;

namespace Code
{
	public sealed class CastOnMaxCountOfTargetsSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<ChipsEntity> _abilities;

		public CastOnMaxCountOfTargetsSystem(Contexts contexts)
		{
			_targets = contexts.game.GetGroup(PickedTarget);
			_abilities = contexts.chips.GetGroup(AllOf(PreparedAbility, MaxCountOfTargets).NoneOf(Cast));
		}

		public void Execute()
		{
			if (_abilities.All((a) => a.maxCountOfTargets.Value == _targets.count))
			{
				foreach (var e in _abilities.GetEntities())
				{
					e.isCast = true;
					e.isPreparedAbility = false;
				}
			}
		}
	}
}