using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.GameLogicSystems
{
	public sealed class UpdateCursorPositionSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly GameEntity _cursor;

		public UpdateCursorPositionSystem(Contexts contexts)
		{
			_contexts = contexts;
			_cursor = contexts.game.cursorEntity;
		}

		public void Initialize()
		{
			_cursor.AddPosition(Vector2.zero);
		}

		public void Execute()
		{
			_cursor.position.Value = _contexts.input.lookReceive.Value;
		}
	}
}