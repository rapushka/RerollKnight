using System;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class ComponentConstraint
	{
		[field: SerializeField] public GameComponentID Component { get; private set; }
		[field: SerializeField] public bool            MustHave  { get; private set; }

		public int Index => Component.Index;

		public bool Match(Entity<GameScope> target) => MustHave == target.HasComponent(Index);
	}
}