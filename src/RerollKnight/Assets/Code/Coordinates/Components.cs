using Code.CodeGeneration.Attributes;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code
{
	[Game] [Behaviour] [Event(Self)] public sealed class CoordinatesComponent : IComponent { [PrimaryEntityIndex] public Coordinates Value; }

	[Game] [Behaviour] [Event(Self)] public sealed class CoordinatesUnderFieldComponent : IComponent { [PrimaryEntityIndex] public Coordinates Value; }

	[Request] [Behaviour] public sealed class CoordinatesRequestComponent : IComponent { public Coordinates Value; }
}