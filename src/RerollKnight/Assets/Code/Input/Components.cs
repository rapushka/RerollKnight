using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class Clicked : FlagComponent, ICleanup<RemoveComponent> { }

	[GameScope] public sealed class Hovered : FlagComponent { }
}