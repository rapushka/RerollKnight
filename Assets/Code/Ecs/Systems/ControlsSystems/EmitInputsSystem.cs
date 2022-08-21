using Code.Unity.Services.Interfaces;
using Entitas;

namespace Code.Ecs.Systems.InputSystems
{
	public sealed class EmitInputsSystem : IExecuteSystem
	{
		private readonly Contexts _contexts;

		public EmitInputsSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private IInputService InputService => _contexts.services.inputService.Value;
		private InputContext Input => _contexts.input;


		public void Execute()
		{
			Input.ReplaceMoveDirection(InputService.Horizontal());
		}
	}
}
