using Entitas.Generic;

namespace Code
{
	[GameScope] public sealed class EnableOutline : FlagComponent, IEvent { }

	[GameScope] public sealed class TargetStateComponent : ValueComponent<TargetState>, IEvent { }

	// can be a target for a chip usage. sometimes 
	[GameScope] public sealed class Target : FlagComponent { }

	// can be picked as a target. right now
	[GameScope] public sealed class AvailableToPick : FlagComponent { }
}