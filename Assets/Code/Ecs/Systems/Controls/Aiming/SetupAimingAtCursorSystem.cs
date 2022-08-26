using System.Collections.Generic;
using Code.Services.Interfaces;
using Code.Workflow.Extensions;
using Entitas;

namespace Code.Ecs.Systems.Controls.Aiming
{
	public sealed class SetupAimingAtCursorSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public SetupAimingAtCursorSystem(Contexts contexts)
			: base(contexts.game)
		{
			_contexts = contexts;
		}

		private GameContext GameContext => _contexts.game;
		private IIdentifierService<int> Identifier => _contexts.services.identifierService.Value;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.ArmsTransform);

		protected override bool Filter(GameEntity entity) => entity.isPlayer;

		protected override void Execute(List<GameEntity> entites)
			=> entites.ForEach((p) => InitializeWeapon(p, InitializeCursor()));

		private GameEntity InitializeCursor()
			=> GameContext.cursorEntity
			              .Do((c) => c.AddId(Identifier.Next()))
			              .Do((c) => c.AddLookAtObjectId(c.id));

		private void InitializeWeapon(GameEntity player, GameEntity cursor)
			=> GameContext.CreateEntity()
			              .Do((a) => a.AddTransform(player.armsTransform))
			              .Do((a) => a.AddLookAtSubjectId(cursor.id));
	}
}