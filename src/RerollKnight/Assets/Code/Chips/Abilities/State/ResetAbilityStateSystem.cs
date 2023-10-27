using Entitas;
using static ChipsMatcher;

namespace Code
{
	public sealed class ResetAbilityStateSystem : ICleanupSystem
	{
		private readonly IGroup<ChipsEntity> _entities;

		public ResetAbilityStateSystem(Contexts contexts) => _entities = contexts.chips.GetGroup(State);

		public void Cleanup()
		{
			foreach (var e in _entities.WhereStateIs(AbilityState.Casted))
				e.ReplaceState(AbilityState.Inactive);
		}
	}
}