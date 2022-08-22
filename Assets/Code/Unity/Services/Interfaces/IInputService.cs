using UnityEngine;

namespace Code.Unity.Services.Interfaces
{
	public interface IInputService
	{
		void Enable();

		void Disable();

		float Walk { get; }

		bool IsJumping { get; }

		Vector2 CursorPosition { get; }
	}
}