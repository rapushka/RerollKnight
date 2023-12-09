using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	[RequestScope] public sealed class Prefab : ValueComponent<EntityBehaviour<GameScope>> { }

	[GameScope] public sealed class ViewTransform : ValueComponent<Transform> { }

	[GameScope] public sealed class LookAt : ValueComponent<Entity<GameScope>>, IEvent<Self> { }

	[GameScope] public sealed class Rotation : ValueComponent<Quaternion>, IEvent<Self> { }

	[GameScope] public sealed class WorldSpaceUi : FlagComponent { }

	[GameScope] public sealed class Camera : FlagComponent, IUnique { }

	[GameScope] public sealed class Visible : FlagComponent, IEvent<Self> { }
}