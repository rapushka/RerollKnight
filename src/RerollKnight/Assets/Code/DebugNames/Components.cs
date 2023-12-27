using Entitas.Generic;

namespace Code.Component
{
	[GameScope, InfrastructureScope] public sealed class DebugName : ValueComponent<string> { }
}