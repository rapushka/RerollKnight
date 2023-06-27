using System.Collections.Generic;
using Entitas;
using static GameMatcher;

namespace Code
{
	public sealed class UnpickChipSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;
		public UnpickChipSystem(Contexts contexts) : base(contexts.game) => _contexts = contexts;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Clicked, PickedChip));

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				_contexts.ToGameState(GameState.PickingChip);
				e.Unpick();
				e.isClicked = false;
			}
		}
	}
}