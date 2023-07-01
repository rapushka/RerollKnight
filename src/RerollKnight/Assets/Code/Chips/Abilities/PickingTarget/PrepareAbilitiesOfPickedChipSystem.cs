using System.Collections.Generic;
using Entitas;

namespace Code
{
	public sealed class PrepareAbilitiesOfPickedChipSystem : ReactiveSystem<GameEntity>
	{
		private readonly IGroup<ChipsEntity> _abilities;

		public PrepareAbilitiesOfPickedChipSystem(Contexts contexts) : base(contexts.game)
			=> _abilities = contexts.chips.GetGroup(ChipsMatcher.AbilityOfChip);

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.PickedChip);

		protected override bool Filter(GameEntity entity) => entity.isPickedChip;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var pickedChip in entites)
			foreach (var ability in _abilities)
			{
				ability.isPreparedAbility = ability.abilityOfChip.Value == pickedChip;
			}
		}
	}
}