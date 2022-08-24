using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Services.Realizations
{
	public class UnityNewInputService : IInputService
	{
		private readonly TopDownControls _input;

		public UnityNewInputService() => _input = new TopDownControls();

		public void Enable() => _input.Enable();

		public void Disable() => _input.Disable();

		public Vector2 Movement => _input.Gameplay.Movement.ReadValue<Vector2>();

		public bool IsJumping => _input.Gameplay.Jump.triggered;

		public Vector2 CursorPosition => _input.Gameplay.Aim.ReadValue<Vector2>();
	}
}