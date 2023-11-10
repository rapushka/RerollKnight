using System;
using Entitas.Generic;

namespace Code
{
	[Serializable]
	public class GameComponentID : ComponentID<GameScope>
	{
		// TODO: move to base ComponentID<TScope>
		public override string ToString() => ComponentsLookup<GameScope>.Instance.ComponentNames[Index];
	}
}