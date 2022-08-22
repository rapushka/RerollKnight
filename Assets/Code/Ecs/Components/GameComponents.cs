using Code.WorkFlow.ComponentsTemplates;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.CleanupMode;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code.Ecs.Components
{
	[Game] [Unique] public sealed class PlayerComponent : FlagComponent { }

	[Game] public sealed class WeightyComponent : FlagComponent { }

	[Game] public sealed class InputReceiverComponent : FlagComponent { }

	[Game] public sealed class RigidbodyComponent : ValueComponent<Rigidbody> { }

	[Game] public sealed class LegsPointTransformComponent : ValueComponent<Transform> { }

	[Game] [Event(Self)] public sealed class PositionComponent : ValueComponent<Vector2> { }

	[Game] [Cleanup(RemoveComponent)] [FlagPrefix("Perform")] public sealed class JumpComponent : FlagComponent { }
}