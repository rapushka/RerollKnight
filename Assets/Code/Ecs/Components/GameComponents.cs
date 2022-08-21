using Code.WorkFlow.ComponentsTemplates;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code.Ecs.Components
{
	[Game] [Unique] public sealed class GravityScaleComponent : ValueComponent<float> { }

	[Game] [Unique] public sealed class PlayerComponent : FlagComponent { }

	[Game] public sealed class WeightyComponent : FlagComponent { }
	
	[Game] public sealed class RigidbodyComponent : ValueComponent<Rigidbody> { }
	[Game] [Event(Self)] public sealed class PositionComponent : ValueComponent<Vector2> { }
}
