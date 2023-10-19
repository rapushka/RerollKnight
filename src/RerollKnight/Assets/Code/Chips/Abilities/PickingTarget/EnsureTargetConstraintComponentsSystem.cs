using System.Linq;
using Entitas;
using static ChipsMatcher;
using static GameMatcher;

namespace Code
{
	public sealed class EnsureTargetConstraintComponentsSystem : IExecuteSystem
	{
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<ChipsEntity> _abilities;

		public EnsureTargetConstraintComponentsSystem(Contexts contexts)
		{
			_targets = contexts.game.GetGroup(PickedTarget);
			_abilities = contexts.chips.GetGroup(AllOf(TargetConstraints, PreparedAbility));
		}

		private bool HasConstraints => _abilities.GetEntities().Any();

		public void Execute()
		{
			if (!HasConstraints)
			{
				SendRequest.UnpickAllTargets();
				return;
			}

			foreach (var ability in _abilities)
			foreach (var target in _targets.GetEntities())
			{
				if (ability.targetConstraints.Value.Any((c) => !target.HasComponent(c.Value)))
				{
					target.Unpick();
					break;
				}
			}
		}
	}
}