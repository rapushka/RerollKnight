using Code.Ecs.Systems.ControlsSystems;
using Code.Ecs.Systems.ControlsSystems.Jumping;
using Code.Ecs.Systems.ControlsSystems.Movement;
using Code.Ecs.Systems.GameLogicSystems;

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
			
			// Jumping
			Add(new GroundCheckSystem(contexts));
			Add(new JumpSystem(contexts));
			
			// Aiming
			Add(new UpdateCursorPositionSystem(contexts));
			Add(new LookAtSystem(contexts));
			
			// Apply
			Add(new ApplyVelocitySystem(contexts));
			Add(new ApplyGravitySystem(contexts));
		}
	}
}
