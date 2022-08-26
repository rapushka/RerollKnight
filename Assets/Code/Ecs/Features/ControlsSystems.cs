using Code.Ecs.Systems.Controls;
using Code.Ecs.Systems.Controls.Aiming;
using Code.Ecs.Systems.Controls.Jumping;
using Code.Ecs.Systems.Controls.Movement;
using Code.Ecs.Systems.GameLogic;
using Code.Ecs.Systems.View;

namespace Code.Ecs.Features
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
			Add(new MovementSystem(contexts));
			Add(new InputToRotationSystem(contexts));
			Add(new TurnByDirectionSystem(contexts));
			
			// Jumping
			Add(new GroundCheckSystem(contexts));
			Add(new JumpSystem(contexts));
			
			// Aiming
			Add(new UpdateCursorPositionSystem(contexts));
			Add(new LockCursorYPosition(contexts));
			Add(new LookAtSystem(contexts));
			
			// Apply
			Add(new ApplyVelocitySystem(contexts));
			Add(new ApplyGravitySystem(contexts));
		}
	}
}
