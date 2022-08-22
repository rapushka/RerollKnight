using Code.Services.Interfaces;
using Code.Workflow.Extensions;
using Entitas;

namespace Code.Ecs.Systems.ViewSystems
{
	public sealed class SetupAimingAtCursorSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public SetupAimingAtCursorSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private GameContext GameContext => _contexts.game;
		private IIdentifierService<int> Identifier => _contexts.services.identifierService.Value;

		public void Initialize()
		{
			GameEntity player = GameContext.playerEntity;
			GameEntity cursor = InitializeCursor();

			InitializeArms(player, cursor);
		}

		private GameEntity InitializeCursor()
			=> GameContext.cursorEntity
			              .Do((c) => c.AddId(Identifier.Next()))
			              .Do((c) => c.AddLookAtObjectId(c.id));

		private void InitializeArms(GameEntity player, GameEntity cursor)
			=> GameContext.CreateEntity()
			              .Do((a) => a.AddTransform(player.armsTransform))
			              .Do((a) => a.AddLookAtSubjectId(cursor.id));
	}
}