using Code.CodeGeneration.Attributes;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Code
{
	[Game] [Behaviour] public sealed class PlayerComponent : IComponent { }

	[Request] [Behaviour] [Cleanup(DestroyEntity)] public sealed class SpawnPlayerComponent : IComponent { }
}