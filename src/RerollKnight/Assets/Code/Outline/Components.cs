using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code
{
	[Game] [Event(Self)] public sealed class OutlineComponent : IComponent { public OutlineParams Value; }
	
	// can be a target for a chip usage. sometimes 
	[Game] public sealed class TargetComponent : IComponent { }

	// can be picked as a target. right now
	[Game] public sealed class AvailableToPickComponent : IComponent { }

}