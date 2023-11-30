using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class CurrentActor : FlagComponent, IUnique { }

	// Both Players and Enemies
	[GameScope] public sealed class Actor : FlagComponent { }

	[RequestScope] public sealed class SpawnActor : FlagComponent, ICleanup<DestroyEntity> { }

	[GameScope] public sealed class ID : PrimaryIndexComponent<GameScope, ID, int> { }

	[GameScope] public sealed class BelongToActor : IndexComponent<GameScope, BelongToActor, int> { }
}