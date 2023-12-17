using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class Reward : FlagComponent { }

	[GameScope] public sealed class ChipConfig : ValueComponent<ChipConfigBehaviour> { }
}