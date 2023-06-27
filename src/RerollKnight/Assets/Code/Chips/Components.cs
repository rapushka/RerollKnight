using Code.CodeGeneration.Attributes;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Code
{
	[Game] [Behaviour] public sealed class ChipComponent : IComponent { }

	[Game] [Behaviour] public sealed class DraggableComponent : IComponent { }

	[Request] [Cleanup(DestroyEntity)] public sealed class ClickComponent : IComponent { }

	[Request] [Cleanup(DestroyEntity)] public sealed class DragComponent : IComponent { }

	[Request] [Cleanup(DestroyEntity)] public sealed class DropComponent : IComponent { }

	[Request] public sealed class ClickedEntityComponent : IComponent { public GameEntity Value; }

	[Game] [Cleanup(RemoveComponent)] public sealed class ClickedComponent : IComponent { }

	[Game] [Unique] public sealed class PickedChipComponent : IComponent { }
}