using Code.Ecs.Systems.Controls;
using Code.Ecs.Systems.Controls.Jumping;
using Code.Ecs.Systems.Controls.Movement;
using Code.Ecs.Systems.GameLogic;
using Code.Ecs.Systems.View;

namespace Code.Ecs.Features.FixedUpdateSystems
{
	public sealed class FixedUpdateSystems : Feature
	{
		public FixedUpdateSystems(Contexts contexts)
			: base(nameof(FixedUpdateSystems))
		{
			// Movement
			Add(new MovementSystem(contexts));
			Add(new TurnByDirectionSystem(contexts));

			// Jumps
			Add(new GroundCheckSystem(contexts));
			
			// Aim
			Add(new LookAtSystem(contexts));

			// Apply
			Add(new ApplyGravitySystem(contexts));
			Add(new ApplyVelocitySystem(contexts));
		}
	}
}