using Code.WorkFlow.ComponentsTemplates;
using Entitas.CodeGeneration.Attributes;
using Packages.Code.Ecs.Components.Workflow;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.CleanupMode;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code.Ecs.Components
{
	// Singletons
	[Game] [Unique] public sealed class PlayerComponent : FlagComponent { }

	[Game] [Unique] public sealed class CursorComponent : FlagComponent { }

	// Entity Parameters
	[Game] public sealed class WeightyComponent : FlagComponent { }

	[Game] public sealed class InputReceiverComponent : FlagComponent { }

	// Events
	[Game] [Event(Self)] public sealed class PositionComponent : ValueComponent<Vector3> { }

	// Cleanups
	[Game] [Cleanup(RemoveComponent)] [FlagPrefix("Perform")] public sealed class JumpComponent : FlagComponent { }

	// Identifiers
	[Game] public sealed class IdComponent : PrimaryComponent<int> { }

	[Game] public sealed class LookAtObjectIdComponent : PrimaryComponent<int> { }

	[Game] public sealed class LookAtSubjectIdComponent : IndexComponent<int> { }

	[Game] public sealed class CurrentWeaponComponent : ValueComponent<GameEntity> { }
}