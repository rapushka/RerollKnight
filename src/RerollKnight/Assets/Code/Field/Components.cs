using Code.CodeGeneration.Attributes;
using Entitas;

namespace Code
{
	[Game] [Behaviour] public sealed class CellComponent : IComponent { }

	[Game] public sealed class PickedTargetComponent : IComponent { }
}