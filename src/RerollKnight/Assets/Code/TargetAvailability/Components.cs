using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.CleanupMode;

namespace Code
{
	[Request] [Cleanup(DestroyEntity)] public sealed class SetAllTargetsAvailabilityComponent : IComponent { public bool Value; }
}