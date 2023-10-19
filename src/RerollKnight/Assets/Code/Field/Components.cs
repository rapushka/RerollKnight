using Code.CodeGeneration.Attributes;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Code
{
	[Game] [Behaviour] public sealed class CellComponent : IComponent { }

	[Game] public sealed class EmptyComponent : IComponent { }

	[Game] public sealed class PickedTargetComponent : IComponent { }

	[Request] [Cleanup(DestroyEntity)] public sealed class UnpickAllTargetsComponent : IComponent { }
}