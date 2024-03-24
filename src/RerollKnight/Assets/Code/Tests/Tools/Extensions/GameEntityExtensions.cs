using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code.Editor.Tests
{
	public static class GameEntityExtensions
	{
		public static Vector3 GetDestinationOrActualPosition(this Entity<GameScope> @this)
			=> @this.Has<DestinationPosition>()
				? @this.Get<DestinationPosition>().Value
				: @this.Get<Position>().Value;
	}
}