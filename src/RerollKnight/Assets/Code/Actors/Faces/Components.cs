using Entitas.Generic;

namespace Code.Component
{
	// [GameScope] public sealed class CountOfFaces : ValueComponent<int>	{ }

	[GameScope] public sealed class Face : ValueComponent<int> { }

	// Is face active
	[GameScope] public sealed class ActiveFace : FlagComponent { }
	// BUT also what face of the actor is active? 
	// [GameScope] public sealed class ActiveFace : ValueComponent<int> { }
}