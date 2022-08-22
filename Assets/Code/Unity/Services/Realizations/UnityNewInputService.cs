using Code.Unity.Services.Interfaces;

namespace Code.Unity.Services.Realizations
{
	public class UnityNewInputService : IInputService
	{
		private readonly PlayerInput _input;

		public UnityNewInputService() 
			=> _input = new PlayerInput();

		public void Enable()
			=> _input.Enable();

		public void Disable()
			=> _input.Disable();

		public float Walk
			=> _input.Gameplay.Walk.ReadValue<float>();

		public bool IsJumping 
			=> _input.Gameplay.Jump.triggered;
	}
}
