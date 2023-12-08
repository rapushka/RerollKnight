using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class TurnUpActiveFaceSystem : ReactiveSystem<Entity<GameScope>>
	{
		public TurnUpActiveFaceSystem(Contexts contexts) : base(contexts.Get<GameScope>()) { }

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(Get<ActiveFace>());

		protected override bool Filter(Entity<GameScope> entity) => entity.Has<ActiveFace>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			foreach (var e in entities)
			{
				var diceBodyEntity = e.GetDependants().Single((b) => b.Is<DiceBody>());

				var activeFaceRotation = e.GetActiveFace().Get<Rotation>().Value;
				var diceTransform = diceBodyEntity.Get<ViewTransform>().Value;

				diceTransform.rotation = activeFaceRotation;

				// active face looks forward
				// diceTransform.rotation = activeFaceRotation;

				// diceTransform.rotation = Quaternion.Euler(90f, 0f, 0f) * activeFaceRotation;
			}
		}
	}
}