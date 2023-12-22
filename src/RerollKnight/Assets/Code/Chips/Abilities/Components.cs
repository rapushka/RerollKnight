using Entitas.Generic;

namespace Code.Component
{
	[ChipsScope] public sealed class SwapPositions : FlagComponent { }

	[ChipsScope] public sealed class DealDamage : ValueComponent<int> { }

	[ChipsScope] public sealed class MaxCountOfTargets : ValueComponent<int> { }

	[ChipsScope] public sealed class Range : ValueComponent<int> { }

	[ChipsScope] public sealed class ConsiderObstacles : FlagComponent { }

	[ChipsScope] public sealed class ConstrainByVisibility : FlagComponent { }
}