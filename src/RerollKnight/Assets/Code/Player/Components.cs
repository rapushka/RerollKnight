using Entitas.Generic;

namespace Code
{
	[GameScope] public sealed class Player : FlagComponent { }

	[RequestScope] public sealed class SpawnPlayer : FlagComponent, ICleanup<DestroyEntity> { }
}