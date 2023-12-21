using Entitas.Generic;

namespace Code.Component
{
	[ChipsScope] public sealed class Teleport : FlagComponent { }

	[ChipsScope] public sealed class SwitchPositions : FlagComponent { }

	[ChipsScope] public sealed class Kick : FlagComponent { }

	[ChipsScope] public sealed class Damage : ValueComponent<int> { }

	[ChipsScope] public sealed class MaxCountOfTargets : ValueComponent<int> { }

	[ChipsScope] public sealed class Range : ValueComponent<int> { }

	[ChipsScope] public sealed class ConsiderObstacles : FlagComponent { }
}