using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class DistanceToPlayer : ValueComponent<int> { }

	[GameScope] public sealed class CurrentStrategy : ValueComponent<EnemyStrategy> { }
}