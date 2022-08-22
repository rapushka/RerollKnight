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

		public void Initialize()
		{
			GameEntity cursor = _contexts.game.CreateEntity();
			cursor.isCursor = true;
			cursor.AddPosition(Vector2.zero);
		}

		public void Execute()
		{
			Cursor.position.Value = _contexts.input.lookReceive.Value;
		}
	}
}