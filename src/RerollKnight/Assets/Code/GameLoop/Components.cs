using Entitas.Generic;

namespace Code.Component
{
	[RequestScope] public sealed class EndTurn : FlagComponent, ICleanup<DestroyEntity> { }
}