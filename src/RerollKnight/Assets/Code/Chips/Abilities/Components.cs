using Entitas.Generic;

namespace Code.Component
{
	// Abilities
	[ChipsScope] public sealed class SwapPositions : FlagComponent { }

	[ChipsScope] public sealed class DealDamage : ValueComponent<int> { }

	[ChipsScope] public sealed class SetNextSide : FlagComponent { }

	[ChipsScope] public sealed class ShowNextSide : FlagComponent { }

	[ChipsScope] public sealed class PushDistance : ValueComponent<int> { }

	// Options (?) 
	[ChipsScope] public sealed class MaxCountOfTargets : ValueComponent<int> { }

	[ChipsScope] public sealed class Range : ValueComponent<int> { }

	[ChipsScope] public sealed class ConsiderObstacles : FlagComponent { }

	[ChipsScope] public sealed class ConstrainByVisibility : FlagComponent { }

	[ChipsScope] public sealed class AllowDiagonals : FlagComponent { }

	[ChipsScope] public sealed class CrashDamage : ValueComponent<int> { }

	[ChipsScope] public sealed class Recoil : ValueComponent<int> { }

	[ChipsScope] public sealed class PerpendicularSpread : ValueComponent<int> { }
}