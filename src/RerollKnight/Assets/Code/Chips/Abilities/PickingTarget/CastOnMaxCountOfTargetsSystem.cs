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
			_abilities = contexts.chips.GetGroup(AllOf(PreparedAbility, MaxCountOfTargets));
		}

		private int TargetsCount => _targets.count;

		public void Execute()
		{
			if (_abilities.All((a) => TargetsCount == a.maxCountOfTargets.Value))
			{
				_abilities.ForEach((a) => a.isCasted = true);
			}
		}
	}
}