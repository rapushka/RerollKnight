using System.Collections.Generic;
using Code.CodeGeneration.Attributes;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Code
{
	[Game] [Behaviour] public sealed class ChipComponent : IComponent { }

	[Game] [Cleanup(RemoveComponent)] public sealed class ClickedComponent : IComponent { }

	[Game] [Unique] public sealed class PickedChipComponent : IComponent { }

	[Request] [Cleanup(DestroyEntity)] public sealed class CastAbilityComponent : IComponent { }

	[Chips] [Behaviour] public sealed class TargetConstraintsComponent : IComponent { public List<int> Value; }
}