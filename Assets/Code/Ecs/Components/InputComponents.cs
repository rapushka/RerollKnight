using Code.WorkFlow.ComponentsTemplates;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Ecs.Components
{
	[Unique] [Input] public sealed class MoveDirectionReceiveComponent : ValueComponent<Vector3> { }

	[Unique] [Input] public sealed class JumpReceiveComponent : FlagComponent { }

	[Unique] [Input] public sealed class LookReceiveComponent : ValueComponent<Vector2> { }
}