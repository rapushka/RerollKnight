using Code.Services.Interfaces;
using Entitas;

namespace Code.Ecs.Systems.ControlsSystems
{
	public sealed class EmitInputsSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		public EmitInputsSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private IInputService InputService => _contexts.services.inputService.Value;
		private InputContext InputContext => _contexts.input;
		
		public void Execute()
		{
			InputContext.ReplaceMoveDirectionReceive(InputService.Walk);
			InputContext.isJumpReceive = InputService.IsJumping;
			InputContext.ReplaceLookReceive(InputService.CursorPosition);
		}
	}
}