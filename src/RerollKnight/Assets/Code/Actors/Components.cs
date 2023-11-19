using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class CurrentActor : FlagComponent, IUnique { }

	// Both Players and Enemies
	[GameScope] public sealed class Actor : FlagComponent { }

	[RequestScope] public sealed class SpawnActor : FlagComponent, ICleanup<DestroyEntity> { }
}