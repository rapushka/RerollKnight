using Code.CodeGeneration.Attributes;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code
{
	[Game] [Event(Self)] [FlagPrefix("")] public sealed class EnableOutlineComponent : IComponent { }

	[Game] [Event(Self)] public sealed class TargetStateComponent : IComponent { public TargetState Value; }
	
	// can be a target for a chip usage. sometimes 
	[Game] [Behaviour] public sealed class TargetComponent : IComponent { }

	// can be picked as a target. right now
	[Game] public sealed class AvailableToPickComponent : IComponent { }

}