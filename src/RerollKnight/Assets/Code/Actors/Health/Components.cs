using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class MaxHealth : ValueComponent<int> { }

	/// Current Health
	[GameScope] public sealed class Health : ValueComponent<int> { }
}