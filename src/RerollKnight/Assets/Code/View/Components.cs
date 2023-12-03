using Entitas.Generic;

namespace Code.Component
{
	[RequestScope] public sealed class Prefab : ValueComponent<EntityBehaviour<GameScope>> { }

	[GameScope] public sealed class RootTransform : ValueComponent<UnityEngine.Transform> { }
}