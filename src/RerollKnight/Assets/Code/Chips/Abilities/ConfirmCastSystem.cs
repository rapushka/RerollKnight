using Entitas;
using static ChipsMatcher;

namespace Code
{
	public sealed class ConfirmCastSystem : IExecuteSystem
	{
		private readonly IGroup<ChipsEntity> _entities;
		private readonly IGroup<ChipsEntity> _abilities;

		public ConfirmCastSystem(Contexts contexts)
		{
			_abilities = contexts.chips.GetGroup(PreparedAbility);
		}

		public void Execute()
		{
			foreach (var ability in _abilities)
			{
				ability.isCasted = true;
			}
		}
	}
}