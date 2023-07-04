using Entitas;
using static ChipsMatcher;
using static Code.GameState;

namespace Code
{
	public sealed class CastAllAbilitiesOnGameStateSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<ChipsEntity> _abilities;

		public CastAllAbilitiesOnGameStateSystem(Contexts contexts)
		{
			_contexts = contexts;
			_abilities = contexts.chips.GetGroup(PreparedAbility);
		}

		public void Execute()
		{
			if (_contexts.GameStateIs(WaitingForAbilityUsage) == false) return;

			foreach (var ability in _abilities)
			{
				ability.isCasted = true;
			}
		}
	}
}