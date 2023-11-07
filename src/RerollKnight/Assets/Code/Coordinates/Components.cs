using Entitas.Generic;

namespace Code
{
	[GameScope] public sealed class CoordinatesComponent
		: PrimaryIndexComponent<GameScope, CoordinatesComponent, Coordinates> { }

	[GameScope] public sealed class CoordinatesUnderField
		: PrimaryIndexComponent<GameScope, CoordinatesUnderField, Coordinates> { }

	[RequestScope] public sealed class CoordinatesRequest : ValueComponent<Coordinates> { }
}