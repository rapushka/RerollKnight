using System.Linq;
using Entitas;

namespace Code
{
	// TODO: needed?
	// public sealed class EnsureTargetConstraintComponentsSystem : IExecuteSystem
	// {
	// 	private readonly IGroup<Entity<GameScope>> _targets;
	// 	private readonly IGroup<ChipsEntity> _abilities;
	//
	// 	public EnsureTargetConstraintComponentsSystem(Contexts contexts)
	// 	{
	// 		_targets = contexts.game.GetGroup(PickedTarget);
	// 		_abilities = contexts.chips.GetGroup(AllOf(TargetConstraints, State));
	// 	}
	//
	// 	private bool HasConstraints => _abilities.GetEntities().Any();
	//
	// 	public void Execute()
	// 	{
	// 		if (!HasConstraints)
	// 			return;
	//
	// 		foreach (var ability in _abilities.WhereStateIs(AbilityState.Prepared))
	// 		foreach (var target in _targets.GetEntities())
	// 		{
	// 			if (ability.targetConstraints.Value.Any((c) => !target.HasComponent(c.Index)))
	// 			{
	// 				target.Unpick();
	// 				break;
	// 			}
	// 		}
	// 	}
	// }
}