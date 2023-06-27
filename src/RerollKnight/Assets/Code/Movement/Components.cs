using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code
{
	[Game] public sealed class InitialPositionComponent : IComponent { public Vector3 Value; }

	[Game] public sealed class DestinationPositionComponent : IComponent { public Vector3 Value; }

	[Game] public sealed class MovingSpeedComponent : IComponent { public float Value; }
	
	[Game] [Event(Self)] public sealed class PositionComponent : IComponent { public Vector3 Value; }
}