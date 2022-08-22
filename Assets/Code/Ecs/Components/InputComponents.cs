using Code.WorkFlow.ComponentsTemplates;
using Entitas.CodeGeneration.Attributes;

namespace Code.Ecs.Components
{
	[Unique] [Input] public sealed class MoveDirectionComponent : ValueComponent<float> { }
	[Unique] [Input] public sealed class JumpingComponent : FlagComponent { }
}