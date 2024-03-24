using System.Collections.Generic;
using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class Chip : FlagComponent { }

	[GameScope] public sealed class PickedChip : FlagComponent, IUnique { }

	[RequestScope] public sealed class CastAbility : FlagComponent, ICleanup<DestroyEntity> { }

	[ChipsScope] public sealed class TargetConstraints : ValueComponent<List<GameComponentConstraint>> { }

	[GameScope] public sealed class Label : ValueComponent<string>, IEvent<Self> { }

	[GameScope] public sealed class Description : ValueComponent<string>, IEvent<Self> { }
}