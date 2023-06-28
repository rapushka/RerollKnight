using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code
{
	[Game] [Unique] public sealed class GameStateComponent : IComponent { public GameState Value; }
}