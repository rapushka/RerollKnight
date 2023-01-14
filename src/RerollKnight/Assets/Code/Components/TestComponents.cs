using Code.CodeGeneration.Attributes;
using Entitas;

namespace Code
{
	[Game] [Authoring] public sealed class EnemyComponent : IComponent { }

	[Game] [Authoring] public sealed class HealthComponent : IComponent { public int Value; }

	[Game] [Authoring] public sealed class SomeComponent : IComponent { public string Value; }
}
