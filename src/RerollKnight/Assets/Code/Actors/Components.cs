using Entitas.Generic;

namespace Code.Component
{
	/// That dude, which makes their turn right now
	[GameScope] public sealed class CurrentActor : FlagComponent, IUnique { }

	/// Both Players and Enemies
	[GameScope] public sealed class Actor : FlagComponent { }

	[GameScope] public sealed class Player : FlagComponent { }

	[GameScope] public sealed class Enemy : FlagComponent { }

	/// Dumb-ass request
	[RequestScope] public sealed class SpawnActor : FlagComponent, ICleanup<DestroyEntity> { }

	[GameScope] public sealed class ID : PrimaryIndexComponent<GameScope, ID, int> { }

	[GameScope] public sealed class BelongToActor : IndexComponent<GameScope, BelongToActor, int> { }
}