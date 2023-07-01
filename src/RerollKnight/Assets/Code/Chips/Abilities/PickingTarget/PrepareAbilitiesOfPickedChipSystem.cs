using System.Collections.Generic;
using Entitas;

namespace Code
{
	public sealed class PrepareAbilitiesOfPickedChipSystem : ReactiveSystem<GameEntity>
	{
		private readonly IGroup<ChipsEntity> _abilities;
		private readonly Contexts _contexts;

		public PrepareAbilitiesOfPickedChipSystem(Contexts contexts) : base(contexts.game)
		{
			_contexts = contexts;
			_abilities = contexts.chips.GetGroup(ChipsMatcher.AbilityOfChip);
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.PickedChip);

		protected override bool Filter(GameEntity entity) => entity.isPickedChip;

		protected override void Execute(List<GameEntity> entites)
		{
			var pickedChip = _contexts.game.pickedChipEntity;
			foreach (var ability in _abilities)
			{
				ability.isPreparedAbility = ability.abilityOfChip.Value == pickedChip;
			}
		}
	}
}