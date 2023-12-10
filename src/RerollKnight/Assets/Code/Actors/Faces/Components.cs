using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class Face : ValueComponent<int> { }

	[GameScope] public sealed class ActiveFace : ValueComponent<int>, IEvent<Self> { }
}