using Entitas.Generic;

namespace Code.Component
{
	[RequestScope] public sealed class SpawnEnemy : FlagComponent, ICleanup<DestroyEntity> { }
}