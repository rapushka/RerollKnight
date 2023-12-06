using Entitas.Generic;

namespace Code.Component
{
	/// That dude, which makes their turn right now
	[GameScope] public sealed class CurrentActor : FlagComponent, IUnique, IEvent<Any> { }

	/// Both Players and Enemies
	[GameScope] public sealed class Actor : FlagComponent { }

	[GameScope] public sealed class Player : FlagComponent { }

	[GameScope] public sealed class Enemy : FlagComponent { }

	/// Dumb-ass request
	[RequestScope] public sealed class SpawnActor : FlagComponent, ICleanup<DestroyEntity> { }

	[GameScope, ChipsScope, RequestScope] public sealed class ID : PrimaryIndexComponent<GameScope, ID, string> { }

	[GameScope, ChipsScope, RequestScope] public sealed class ForeignID : IndexComponent<ForeignID, string> { }

	[GameScope] public sealed class CountOfFaces : ValueComponent<int> { }
}