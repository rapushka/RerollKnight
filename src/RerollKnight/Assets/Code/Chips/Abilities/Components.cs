using Code.CodeGeneration.Attributes;
using Entitas;

namespace Code
{
	[Chips] [Behaviour] public sealed class TeleportComponent : IComponent { }

	[Chips] [Behaviour] public sealed class MaxCountOfTargetsComponent : IComponent { public int Value; }

	[Chips] public sealed class TargetsComponent : IComponent { public GameEntity[] Value; }

	[Chips] [Behaviour] public sealed class MaxRangeToTargetComponent : IComponent { public int Value; }

	[Chips] [Behaviour] public sealed class TargetMustBeEmptyCellComponent : IComponent { }

	[Chips] public sealed class AbilityOfChipComponent : IComponent { public GameEntity Value; }

	[Chips] public sealed class CastedComponent : IComponent { }
}