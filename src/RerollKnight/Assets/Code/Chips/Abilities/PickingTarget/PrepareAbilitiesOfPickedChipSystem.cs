using System.Collections.Generic;
using Entitas;
using static ChipsMatcher;

namespace Code
{
	public sealed class PrepareAbilitiesOfPickedChipSystem : ReactiveSystem<GameEntity>
	{
		private readonly IGroup<ChipsEntity> _abilities;
		private readonly Contexts _contexts;

		public PrepareAbilitiesOfPickedChipSystem(Contexts contexts) : base(contexts.game)
		{
			_contexts = contexts;
			_abilities = contexts.chips.GetGroup(AbilityOfChip);
		}

		private GameEntity PickedChip => _contexts.game.pickedChipEntity;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.PickedChip);

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var ability in _abilities)
			{
				ability.isPreparedAbility = ability.abilityOfChip.Value == PickedChip;
			}
		}
	}
}