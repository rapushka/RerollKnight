using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class EnableOutline : FlagComponent, IEvent<Self> { }

	[GameScope] public sealed class TargetState : ValueComponent<Code.TargetState>, IEvent<Self> { }

	/// <summary> can be a target for an ability, in general </summary>
	[GameScope] public sealed class Target : FlagComponent { }

	/// <summary> can be picked as a target, right now </summary>
	[GameScope] public sealed class AvailableToPick : FlagComponent, IEvent<Self> { }
}