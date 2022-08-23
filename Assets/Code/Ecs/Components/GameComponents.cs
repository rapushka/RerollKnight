using Code.WorkFlow.ComponentsTemplates;
using Entitas.CodeGeneration.Attributes;
using Packages.Code.Ecs.Components.Workflow;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.CleanupMode;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code.Ecs.Components
{
	[Game] [Unique] public sealed class PlayerComponent : FlagComponent { }

	[Game] public sealed class WeightyComponent : FlagComponent { }

	[Game] public sealed class InputReceiverComponent : FlagComponent { }

	[Game] public sealed class RigidbodyComponent : ValueComponent<Rigidbody> { }

	[Game] public sealed class TransformComponent : ValueComponent<Transform> { }

	[Game] public sealed class LegsPointTransformComponent : ValueComponent<Transform> { }

	[Game] public sealed class ArmsTransformComponent : ValueComponent<Transform> { }

	[Game] [Event(Self)] public sealed class PositionComponent : ValueComponent<Vector2> { }

	[Game] [Cleanup(RemoveComponent)] [FlagPrefix("Perform")] public sealed class JumpComponent : FlagComponent { }

	[Game] public sealed class IdComponent : PrimaryComponent<int> { }

	[Game] public sealed class LookAtObjectIdComponent : PrimaryComponent<int> { }

	[Game] public sealed class LookAtSubjectIdComponent : IndexComponent<int> { }

	[Game] [Unique] public sealed class CursorComponent : FlagComponent { }
}