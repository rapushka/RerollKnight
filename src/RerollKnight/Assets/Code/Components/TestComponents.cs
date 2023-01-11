using Code.CodeGeneration.Attributes;

namespace Code
{
	[Game] [Authoring] public sealed class EnemyComponent : FlagComponent { }

	[Game] [Authoring] public sealed class HealthComponent : ValueComponent<int> { }
}
