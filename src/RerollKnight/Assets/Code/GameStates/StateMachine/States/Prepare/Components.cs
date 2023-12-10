using Entitas.Generic;

namespace Code.Component
{
	[InfrastructureScope] public sealed class Ready : ValueComponent<bool> { }

	[InfrastructureScope] public sealed class SpentTime : ValueComponent<float> { }

	[InfrastructureScope] public sealed class WholeTime : ValueComponent<float> { }
}