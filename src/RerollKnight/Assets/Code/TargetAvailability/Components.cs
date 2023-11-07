using Entitas.Generic;

namespace Code
{
	[RequestScope] public sealed class SetAllTargetsAvailability : ValueComponent<bool>, ICleanup<DestroyEntity> { }
}