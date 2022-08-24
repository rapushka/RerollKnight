using Code.Services.Interfaces;
using Entitas;

namespace Code.Ecs.Systems.ControlsSystems
{
	public sealed class EmitInputsSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly Contexts _contexts;

		public EmitInputsSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private IInputService InputService => _contexts.services.inputService.Value;
		private InputContext InputContext => _contexts.input;

		public void Initialize()
		{
			InputContext.SetMoveDirectionReceive(InputService.Walk);
			InputContext.SetLookReceive(InputService.CursorPosition);
		}

		public void Execute()
		{
			InputContext.moveDirectionReceive.Value = InputService.Walk;
			InputContext.isJumpReceive = InputService.IsJumping;
			InputContext.lookReceive.Value = InputService.CursorPosition;
		}
	}
}