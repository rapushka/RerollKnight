using Entitas.Generic;

namespace Code.Component
{
	// Abilities
	[ChipsScope] public sealed class SwapPositions : FlagComponent { }

	[ChipsScope] public sealed class DealDamage : ValueComponent<int> { }

	[ChipsScope] public sealed class SetNextSide : FlagComponent { }

	[ChipsScope] public sealed class ShowNextSide : FlagComponent { }

	[ChipsScope] public sealed class PushDistance : ValueComponent<int> { }

	[ChipsScope] public sealed class MoveChipToSide : FlagComponent { }

	// Options (?) 
	[ChipsScope] public sealed class MaxCountOfTargets : ValueComponent<int> { }

	[ChipsScope] public sealed class Range : ValueComponent<int> { }

	[ChipsScope] public sealed class InactiveRange : ValueComponent<int> { }

	/// <summary> There must be a path to the target </summary>
	[ChipsScope] public sealed class ConsiderObstacles : FlagComponent { }

	/// <summary> The target must be visible </summary>
	[ChipsScope] public sealed class ConstrainByVisibility : FlagComponent { }

	[ChipsScope] public sealed class AllowDiagonals : FlagComponent { }

	[ChipsScope] public sealed class CrashDamage : ValueComponent<int> { }

	[ChipsScope] public sealed class Recoil : ValueComponent<int> { }

	[ChipsScope] public sealed class PerpendicularSpread : ValueComponent<int> { }
}