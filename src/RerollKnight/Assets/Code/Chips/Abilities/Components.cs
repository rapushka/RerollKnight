using Code.CodeGeneration.Attributes;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Code
{
	[Chips] [Behaviour] public sealed class TeleportComponent : IComponent { }

	[Chips] [Behaviour] public sealed class MaxCountOfTargetsComponent : IComponent { public int Value; }

	[Chips] [Behaviour] public sealed class MaxRangeToTargetComponent : IComponent { public int Value; }

	[Chips] [Behaviour] public sealed class TargetMustBeEmptyCellComponent : IComponent { }

	[Chips] public sealed class AbilityOfChipComponent : IComponent { public GameEntity Value; }

	[Chips] [Cleanup(RemoveComponent)] public sealed class CastedComponent : IComponent { }

	[Chips] public sealed class PreparedAbilityComponent : IComponent { }
}