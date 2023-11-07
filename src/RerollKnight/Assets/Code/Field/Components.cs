using Entitas.Generic;

namespace Code
{
	[GameScope] public sealed class Cell : FlagComponent { }

	[GameScope] public sealed class Empty : FlagComponent { }

	[GameScope] public sealed class PickedTarget : FlagComponent { }

	[RequestScope] public sealed class UnpickAllTargets : FlagComponent, ICleanup<DestroyEntity> { }
}