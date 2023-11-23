using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	// todo: useless
	public sealed class StoreChipPositionSystem : ReactiveSystem<Entity<GameScope>>
	{
		public StoreChipPositionSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Chip>(), Get<Position>()).NoneOf(Get<InitialPosition>()));

		protected override bool Filter(Entity<GameScope> entity) => true;

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
				e.Replace<InitialPosition, Vector3>(e.Get<Position>().Value);
		}
	}
}