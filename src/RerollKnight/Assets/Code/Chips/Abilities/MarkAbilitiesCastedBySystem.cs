using Entitas;
using static ChipsMatcher;
using static Code.GameState;

namespace Code
{
	public sealed class MarkAbilitiesCastedBySystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<ChipsEntity> _abilities;

		public MarkAbilitiesCastedBySystem(Contexts contexts)
		{
			_contexts = contexts;
			_abilities = contexts.chips.GetGroup(PreparedAbility);
		}

		public void Execute()
		{
			if (!_contexts.GameStateIs(WaitingForAbilityUsage))
				return;

			foreach (var ability in _abilities)
			{
				ability.isCast = true;
			}
		}
	}
}