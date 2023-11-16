using Entitas.Generic;

namespace Code.Component
{
	[ChipsScope] public sealed class Teleport : FlagComponent { }

	[ChipsScope] public sealed class MaxCountOfTargets : ValueComponent<int> { }

	[ChipsScope] public sealed class Range : ValueComponent<int> { }

	// [ChipsScope] [Behaviour] public sealed class TargetMustBeEmptyCell : FlagComponent { }
	[ChipsScope] public sealed class AbilityOfChip : IndexComponent<ChipsScope, AbilityOfChip, int> { }

	[GameScope] public sealed class ChipId : PrimaryIndexComponent<GameScope, ChipId, int> { }
	// [ChipsScope] public sealed class AbilityOfChip : ValueComponent<Entity<GameScope>> { }
}