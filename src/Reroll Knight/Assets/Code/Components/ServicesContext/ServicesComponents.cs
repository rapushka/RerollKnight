using Entitas.CodeGeneration.Attributes;

namespace Code
{
	[Services] [Unique] public sealed class SceneTransferComponent : ValueComponent<SceneTransferService> { }

	[Game] public sealed class HealthComponent : ValueComponent<int> { }
	[Game] public sealed class EnemyComponent : FlagComponent { }
}