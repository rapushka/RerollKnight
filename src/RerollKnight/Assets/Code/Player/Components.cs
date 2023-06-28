using Code.CodeGeneration.Attributes;
using Entitas;

namespace Code
{
	[Game] [Behaviour] public sealed class PlayerComponent : IComponent { }

	[Request] [Behaviour] public sealed class SpawnPlayerComponent : IComponent { }
}