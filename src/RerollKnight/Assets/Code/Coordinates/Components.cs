using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class Coordinates : PrimaryIndexComponent<GameScope, Coordinates, Code.Coordinates> { }

	[GameScope] public sealed class CoordinatesUnderField
		: PrimaryIndexComponent<GameScope, CoordinatesUnderField, Code.Coordinates> { }

	[RequestScope] public sealed class CoordinatesRequest : ValueComponent<Code.Coordinates> { }
}