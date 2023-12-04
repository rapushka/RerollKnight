using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	[RequestScope] public sealed class Prefab : ValueComponent<EntityBehaviour<GameScope>> { }

	[GameScope] public sealed class ViewTransform : ValueComponent<Transform> { }

	[GameScope] public sealed class LookAt : ValueComponent<Transform>, IEvent<Self> { }

	[GameScope] public sealed class Rotation : ValueComponent<Quaternion>, IEvent<Self> { }
}