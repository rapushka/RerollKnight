using Code.Services.Interfaces;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.Controls
{
	public sealed class EmitInputsSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;

		public EmitInputsSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private Vector3 TopDownMoveDirection => new(InputService.Movement.x, 0f, InputService.Movement.y);
		private IInputService InputService => _contexts.services.inputService.Value;
		private InputContext InputContext => _contexts.input;

		public void Initialize()
		{
			InputContext.SetMoveDirectionReceive(InputService.Movement);
			InputContext.SetLookReceive(InputService.CursorPosition);
		}

		public void Execute()
		{
			InputContext.moveDirectionReceive.Value = TopDownMoveDirection;
			InputContext.isJumpReceive = InputService.IsJumping;
			InputContext.lookReceive.Value = InputService.CursorPosition;
		}
	}
}