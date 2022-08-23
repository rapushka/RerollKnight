using Code.Services.Interfaces;
using Entitas;

namespace Code.Ecs.Systems.ControlsSystems
{
	public sealed class InputLiveCycleSystem : IInitializeSystem, ITearDownSystem
	{
		private readonly Contexts _contexts;

		public InputLiveCycleSystem(Contexts contexts)
			=> _contexts = contexts;

		private IInputService InputService => _contexts.services.inputService.Value;

		public void Initialize()
			=> InputService.Enable();

		public void TearDown()
			=> InputService.Disable();
	}
}
