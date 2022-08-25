using Code.Services.Interfaces;
using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.GameLogicSystems
{
	public sealed class UpdateCursorPositionSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;

		public UpdateCursorPositionSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private GameEntity Cursor => _contexts.game.cursorEntity;
		private ISceneService Scene => _contexts.services.sceneService.Value;
		private Vector2 AimingValue => _contexts.input.lookReceive.Value;

		public void Initialize()
			=> _contexts.game.CreateEntity()
			            .Do((c) => c.isCursor = true)
			            .Do((c) => c.AddPosition(Vector2.zero));

		public void Execute() => Cursor.position.Value = Scene.ScreenToWorldPoint(AimingValue);
	}
}