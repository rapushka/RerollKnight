using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class RepickChipSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public RepickChipSystem(Contexts contexts) : base(contexts.game) => _contexts = contexts;

		private bool HasPickedChip => _contexts.game.isPickedChip;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Clicked, Chip).NoneOf(PickedChip));

		protected override bool Filter(GameEntity entity) => HasPickedChip;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				var previousPickedChip = _contexts.game.pickedChipEntity;
				previousPickedChip.Unpick();
				SendRequest.UnpickTargets();
				e.Pick();
				e.isClicked = false;
			}
		}
	}
}