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
			_targets = contexts.game.GetGroup(PickedTarget);
			_abilities = contexts.chips.GetGroup(AllOf(TargetMustBeEmptyCell, PreparedAbility));
		}

		private bool HasConstraints => _abilities.GetEntities().Any();

		private bool HasEntityOnPickedCoordinates => _targets.GetEntities().Any(EntityOnCoordinates);

		public void Execute()
		{
			if (HasConstraints && HasEntityOnPickedCoordinates)
			{
				SendRequest.UnpickAllTargets();
			}
		}

		private bool EntityOnCoordinates(GameEntity target)
			=> _contexts.game.HasEntityWithCoordinates(target.coordinatesUnderField.Value);
	}
}