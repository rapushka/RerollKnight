using Entitas.Generic;

namespace Code
{
	// TODO: [Behaviour]
	[GameScope] public sealed class Player : FlagComponent { }

	// TODO: [Behaviour]
	[RequestScope] public sealed class SpawnPlayer : FlagComponent, ICleanup<DestroyEntity> { }
}