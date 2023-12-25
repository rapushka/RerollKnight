using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class Hoverable : FlagComponent, IEvent<Self> { }
}