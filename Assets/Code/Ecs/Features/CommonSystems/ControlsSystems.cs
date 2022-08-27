using Code.Ecs.Systems.Controls;
using Code.Ecs.Systems.Controls.Aiming;
using Code.Ecs.Systems.Controls.Jumping;
using Code.Ecs.Systems.Controls.Movement;
using Code.Ecs.Systems.GameLogic;
using Code.Ecs.Systems.View;

namespace Code.Ecs.Features.CommonSystems
{
	public sealed class ControlsSystems : Feature
	{
		public ControlsSystems(Contexts contexts)
			: base(nameof(ControlsSystems))
		{
			// Common
			Add(new InputLiveCycleSystem(contexts));
			Add(new EmitInputsSystem(contexts));
			
			// Movement
			Add(new InputToRotationSystem(contexts));
			
			// Jumps
			Add(new JumpSystem(contexts));
			
			// Aim
			Add(new UpdateCursorPositionSystem(contexts));
			Add(new LockCursorYPosition(contexts));
		}
	}
}
