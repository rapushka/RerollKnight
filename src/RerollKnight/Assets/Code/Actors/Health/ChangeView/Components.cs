using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class HealthChange : ValueComponent<int>, IEvent<Self> { }
}