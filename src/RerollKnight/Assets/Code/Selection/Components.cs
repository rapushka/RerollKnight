using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code
{
	[Game] [Event(Self)] public sealed class OutlineComponent : IComponent { public OutlineParams Value; }
}