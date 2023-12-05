using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class MaxHealth : ValueComponent<int>, IEvent<Self> { }

	/// Current Health
	[GameScope] public sealed class Health : ValueComponent<int>, IEvent<Self> { }

	[RequestScope] public sealed class ChangeHealth : ValueComponent<int> { }

	[GameScope, ChipsScope, RequestScope] public sealed class Destroyed : FlagComponent, ICleanup<DestroyEntity>, IEvent<Self> { }
}