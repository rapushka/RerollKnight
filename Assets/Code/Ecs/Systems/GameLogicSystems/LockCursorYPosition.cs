using Code.Workflow.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.GameLogicSystems
{
	public sealed class LockCursorYPosition : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<GameEntity> _entities;

		public LockCursorYPosition(Contexts contexts)
		{
			_contexts = contexts;
		}

		private Vector3 Lock => _contexts.services.balanceService.Value.Player.CrosshairLock;
		private GameEntity Cursor => _contexts.game.cursorEntity;

		public void Execute()
		{
			Cursor.position.Do((p) => p.Value.x = Lock.x, @if: IsNotZero(Lock.x));
			Cursor.position.Do((p) => p.Value.y = Lock.y, @if: IsNotZero(Lock.y));
			Cursor.position.Do((p) => p.Value.z = Lock.z, @if: IsNotZero(Lock.z));
		}

		private static bool IsNotZero(float number) => number != 0;
	}
}