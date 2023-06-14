using Code.CodeGeneration.Attributes;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code
{
	[Game] [Behaviour] public sealed class PlayerComponent : IComponent { }

	[Game] [Behaviour] public sealed class RequireSpawnPlayerComponent : IComponent { }

	[Game] [Behaviour] [Event(Self)] public sealed class CoordinatesComponent : IComponent { [PrimaryEntityIndex] public Coordinates Value; }
}