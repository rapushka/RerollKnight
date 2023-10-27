using Entitas;
using static ChipsMatcher;

namespace Code
{
	public sealed class AddAbilityStateSystem : IInitializeSystem
	{
		private readonly IGroup<ChipsEntity> _entities;

		public AddAbilityStateSystem(Contexts contexts)
			=> _entities = contexts.chips.GetGroup(AllOf(AbilityOfChip).NoneOf(State));

		public void Initialize()
		{
			foreach (var e in _entities.GetEntities())
				e.ReplaceState(AbilityState.Inactive);
		}
	}
}