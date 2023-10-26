using Entitas;
using static ChipsMatcher;

namespace Code
{
	public sealed class MarkAbilitiesCastedBySystem : IExecuteSystem
	{
		private readonly IGroup<ChipsEntity> _abilities;

		public MarkAbilitiesCastedBySystem(Contexts contexts)
		{
			_abilities = contexts.chips.GetGroup(PreparedAbility);
		}

		public void Execute()
		{
			if (ServicesMediator.GameStateMachine.CurrentState is not WaitingGameState)
				return;

			foreach (var ability in _abilities)
			{
				ability.isCast = true;
			}
		}
	}
}