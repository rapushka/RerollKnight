using System.Collections.Generic;
using Code.Unity.Views;
using Entitas;
using Object = UnityEngine.Object;

namespace Code.Ecs.Systems.ReactiveSystems
{
	public sealed class BindPositionViewSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;
		private PositionView _playerPrefabCash;

		public BindPositionViewSystem(Contexts contexts) 
			: base(contexts.game)
		{
			_contexts = contexts;
		}

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.Position);

		protected override bool Filter(GameEntity entity)
			=> entity.hasPosition && entity.isPlayer;

		protected override void Execute(List<GameEntity> entities)
		{
			PositionView playerPrefabCash = _playerPrefabCash
				??= _contexts.game.viewService.Value.PlayerPosition;

			foreach (GameEntity e in entities)
			{
				PositionView positionView = Object.Instantiate(playerPrefabCash);
				positionView.Construct(e);
			}
		}
	}
}
