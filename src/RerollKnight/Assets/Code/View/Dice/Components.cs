using Entitas.Generic;

namespace Code.Component
{
	/// <summary> Detached from field. E.g rerolling. Also will hide limbs for dices </summary>
	[GameScope] public sealed class Detached : FlagComponent, IEvent<Self> { }
	
	[GameScope] public sealed class DiceBody : ValueComponent<Entity<GameScope>> { }
}