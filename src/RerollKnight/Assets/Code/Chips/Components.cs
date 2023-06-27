using Code.CodeGeneration.Attributes;
using Entitas;

namespace Code
{
	[Game] [Behaviour] public sealed class ChipComponent : IComponent { }

	[Game] [Behaviour] public sealed class DraggableComponent : IComponent { }

	[Request] public sealed class ClickComponent : IComponent { }

	[Request] public sealed class DragComponent : IComponent { }

	[Request] public sealed class DropComponent : IComponent { }
}