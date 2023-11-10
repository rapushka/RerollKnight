using Entitas.Generic;

namespace Code.Component
{
	[RequestScope] public sealed class SetAllTargetsAvailability : ValueComponent<bool>, ICleanup<DestroyEntity> { }
}