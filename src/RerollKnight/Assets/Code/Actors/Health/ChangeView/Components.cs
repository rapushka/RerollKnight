using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class HealthChanged : ValueComponent<int>, IEvent<Self> { }

	[GameScope] public sealed class DestroyAfterReachingDestination : FlagComponent { }
}