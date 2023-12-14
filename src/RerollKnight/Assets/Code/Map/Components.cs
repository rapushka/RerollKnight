using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class RoomResident : FlagComponent { }

	[GameScope] public sealed class Disabled : FlagComponent, IEvent<Self> { }

	[GameScope] public sealed class CashedLayer : ValueComponent<Code.Coordinates.Layer> { }
	
	[GameScope] public sealed class Room : FlagComponent { }

	[GameScope] public sealed class NextRoom : FlagComponent, IUnique { }

	[GameScope] public sealed class DoorTo : ValueComponent<Entity<GameScope>> { }
}