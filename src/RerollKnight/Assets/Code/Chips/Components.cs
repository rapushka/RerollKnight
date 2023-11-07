using System.Collections.Generic;
using Entitas.Generic;

namespace Code
{
	[GameScope] public sealed class Chip : FlagComponent { }

	[GameScope] public sealed class Clicked : FlagComponent, ICleanup<RemoveComponent> { }

	[GameScope] public sealed class PickedChip : FlagComponent, IUnique { }

	[RequestScope] public sealed class CastAbility : FlagComponent, ICleanup<DestroyEntity> { }

	[ChipsScope] public sealed class TargetConstraints : ValueComponent<List<GameComponentID>> { }
}