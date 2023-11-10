using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class EnableOutline : FlagComponent, IEvent { }

	[GameScope] public sealed class TargetState : ValueComponent<Code.TargetState>, IEvent { }

	/// <summary>can be a target for a chip usage. sometimes </summary>
	[GameScope] public sealed class Target : FlagComponent { }

	/// <summary> can be picked as a target.right now </summary>
	[GameScope] public sealed class AvailableToPick : FlagComponent { }
}