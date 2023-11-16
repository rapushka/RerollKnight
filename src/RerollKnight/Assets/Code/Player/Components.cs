using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class Player : FlagComponent { }

	[RequestScope] public sealed class SpawnPlayer : FlagComponent, ICleanup<DestroyEntity> { }

	[RequestScope] public sealed class SpawnEnemy : FlagComponent, ICleanup<DestroyEntity> { }
}