using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class UnhoverUnpickedChipSystem : ReactiveSystem<Entity<GameScope>>
	{
		public UnhoverUnpickedChipSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<PickedChip>(), Get<Position>()));

		protected override bool Filter(Entity<GameScope> entity) => !entity.Is<PickedChip>();

		protected override void Execute(List<Entity<GameScope>> entites)
		{
			foreach (var e in entites)
				e.Replace<DestinationPosition, Vector3>(e.Get<InitialPosition>().Value);
		}
	}
}