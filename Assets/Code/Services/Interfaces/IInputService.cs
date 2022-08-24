using UnityEngine;

namespace Code.Services.Interfaces
{
	public interface IInputService
	{
		void Enable();

		void Disable();

		Vector2 Walk { get; }

		bool IsJumping { get; }

		Vector2 CursorPosition { get; }
	}
}