using System.Collections.Generic;
using Entitas;
using UnityEngine;
using static GameMatcher;

namespace Code
{
	public sealed class PickChipSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public PickChipSystem(Contexts contexts)
			: base(contexts.game)
			=> _contexts = contexts;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(AllOf(Clicked, Chip));

		protected override bool Filter(GameEntity entity) => entity.isClicked;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				_contexts.ToGameState(GameState.PickingTarget);
				e.isPickedChip = true;
				Debug.Log("is picked");
			}
		}
	}
}