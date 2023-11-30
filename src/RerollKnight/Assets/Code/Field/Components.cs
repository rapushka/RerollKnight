using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class Cell : FlagComponent { }

	[GameScope] public sealed class Empty : FlagComponent { }

	[GameScope] public sealed class PickedTarget : FlagComponent { }
}