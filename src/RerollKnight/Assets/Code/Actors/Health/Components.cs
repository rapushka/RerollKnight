using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class MaxHealth : ValueComponent<int> { }

	/// Current Health
	[GameScope] public sealed class Health : ValueComponent<int> { }

	[RequestScope] public sealed class ChangeHealth : ValueComponent<int> { }

	[RequestScope] public sealed class AttachedTo : IndexComponent<RequestScope, AttachedTo, int> { }
}