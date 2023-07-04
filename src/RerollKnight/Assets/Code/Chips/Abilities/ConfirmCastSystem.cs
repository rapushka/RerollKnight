using Entitas;
using static ChipsMatcher;

namespace Code
{
	public sealed class ConfirmCastSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<ChipsEntity> _abilities;

		public ConfirmCastSystem(Contexts contexts)
		{
			_contexts = contexts;
			_abilities = contexts.chips.GetGroup(PreparedAbility);
		}

		public void Execute()
		{
			if (_contexts.GameStateIs(GameState.WaitingForAbilityUsage) == false) return;

			foreach (var ability in _abilities)
			{
				ability.isCasted = true;
			}
		}
	}
}