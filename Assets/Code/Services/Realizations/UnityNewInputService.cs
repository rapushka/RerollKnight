using Code.Services.Interfaces;
using UnityEngine;

namespace Code.Services.Realizations
{
	public class UnityNewInputService : IInputService
	{
		private readonly PlayerInput _input;

		public UnityNewInputService() => _input = new PlayerInput();

		public void Enable() => _input.Enable();

		public void Disable() => _input.Disable();

		public float Walk => _input.Gameplay.Walk.ReadValue<float>();

		public bool IsJumping => _input.Gameplay.Jump.triggered;

		public Vector2 CursorPosition => _input.Gameplay.Aim.ReadValue<Vector2>();
	}
}