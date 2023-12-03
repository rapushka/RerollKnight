using System;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class ComponentConstraint
	{
		// todo: for any scope
		[field: SerializeField] public GameComponentID Component { get; private set; }
		[field: SerializeField] public bool            MustHave  { get; private set; }

		public int Index => Component.Index;

		public bool Match(Entity<GameScope> target) => MustHave == target.HasComponent(Index);

		public bool Is<TComponent>()
			where TComponent : IComponent, new()
			=> MustHave && Component.Index == ComponentIndex<GameScope, TComponent>.Value;
	}
}