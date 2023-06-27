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

		protected override bool Filter(GameEntity entity) => true;

		protected override void Execute(List<GameEntity> entites)
		{
			foreach (var e in entites)
			{
				if (_contexts.game.isPickedChip)
				{
					var previousPickedChip = _contexts.game.pickedChipEntity;
					if (previousPickedChip != e)
					{
						previousPickedChip.isPickedChip = false;
					}
					else
					{
						ToGameState(GameState.PickingChip);
						break;
					}
				}

				ToGameState(GameState.PickingTarget);
				e.isPickedChip = true;
				Debug.Log("chip is picked");
			}
		}

		private void ToGameState(GameState state) => _contexts.game.ReplaceGameState(state);
	}
}