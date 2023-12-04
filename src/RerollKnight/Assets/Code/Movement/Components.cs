using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	[GameScope] public sealed class InitialPosition : ValueComponent<Vector3> { }

	[GameScope] public sealed class DestinationPosition : ValueComponent<Vector3> { }

	[GameScope] public sealed class MovingSpeed : ValueComponent<float> { }

	[GameScope] public sealed class Position : ValueComponent<Vector3>, IEvent<Self> { }
}