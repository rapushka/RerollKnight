using System;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	[Serializable]
	public abstract class ComponentConstraint<TScope>
		where TScope : IScope
	{
		[field: SerializeField] public ComponentID<TScope> Component { get; private set; }
		[field: SerializeField] public bool                MustHave  { get; private set; }

		public int Index => Component.Index;

		public bool Match(Entity<GameScope> target) => MustHave == target.HasComponent(Index);

		public bool Is<TComponent>()
			where TComponent : IComponent, new()
			=> MustHave && Component.Index == ComponentIndex<GameScope, TComponent>.Value;
	}

	[Serializable]
	public class GameComponentConstraint
	{
		[field: SerializeField] public GameComponentID Component { get; private set; }
		[field: SerializeField] public bool            MustHave  { get; private set; }

		public int Index => Component.Index;

		public bool Match(Entity<GameScope> target) => MustHave == target.HasComponent(Index);

		public bool Is<TComponent>()
			where TComponent : IComponent, new()
			=> MustHave && Component.Index == ComponentIndex<GameScope, TComponent>.Value;
	}
}