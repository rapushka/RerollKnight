using System;
using Entitas.Generic;

namespace Code
{
	[Serializable] public class GameComponentID : ComponentID<GameScope> { }

	[Serializable] public class ChipsComponentID : ComponentID<ChipsScope> { }
}