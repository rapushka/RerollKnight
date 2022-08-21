using Code.Ecs.Systems.ControlsSystems;
using Code.Ecs.Systems.InputSystems;

namespace Code.Ecs.Features
{
	public sealed class ControlsSystems : Feature
	{
		public ControlsSystems(Contexts contexts)
			: base(nameof(ControlsSystems))
		{
			Add(new InputLiveCycleSystem(contexts));
			Add(new EmitInputsSystem(contexts));
			
			Add(new MovementSystem(contexts));
		}
	}
}
