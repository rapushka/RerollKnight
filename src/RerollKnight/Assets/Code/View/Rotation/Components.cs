using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	[GameScope] public sealed class Rotation : ValueComponent<Quaternion>, IEvent<Self> { }

	[GameScope] public sealed class DestinationRotation : ValueComponent<Quaternion>, IEvent<Self> { }

	[GameScope] public sealed class RotationSpeed : ValueComponent<float> { }

	[GameScope] public sealed class LookAt : ValueComponent<Entity<GameScope>>, IEvent<Self> { }

	[GameScope] public sealed class RandomlyRotating : FlagComponent { }
}