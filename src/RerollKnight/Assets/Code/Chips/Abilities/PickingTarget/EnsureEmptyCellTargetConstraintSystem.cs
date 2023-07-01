using System.Linq;
using Entitas;
using static ChipsMatcher;
using static GameMatcher;

namespace Code
{
	public sealed class EnsureEmptyCellTargetConstraintSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<GameEntity> _targets;
		private readonly IGroup<ChipsEntity> _abilities;

		public EnsureEmptyCellTargetConstraintSystem(Contexts contexts)
		{
			_contexts = contexts;
			_targets = contexts.game.GetGroup(AllOf(PickedTarget, Cell));
			_abilities = contexts.chips.GetGroup(AllOf(TargetMustBeEmptyCell, PreparedAbility));
		}

		private bool HasConstraints => _abilities.GetEntities().Any();

		public void Execute()
		{
			if (HasConstraints)
			{
				Constraint();
			}
		}

		private void Constraint()
		{
			foreach (var target in _targets.GetEntities())
			{
				var pickedCoordinates = target.coordinatesUnderField.Value;

				if (_contexts.game.HasEntityWithCoordinates(pickedCoordinates))
				{
					SendRequest.UnpickAllTargets();
				}
			}
		}
	}
}