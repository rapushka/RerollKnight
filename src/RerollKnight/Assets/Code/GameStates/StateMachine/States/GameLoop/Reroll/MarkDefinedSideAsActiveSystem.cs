using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class MarkDefinedSideAsActiveSystem : ITearDownSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<GameScope>> _actors;

		public MarkDefinedSideAsActiveSystem(Contexts contexts)
			=> _actors = contexts.GetGroup(AllOf(Get<Actor>(), Get<PredefinedNextSide>()));

		public void TearDown()
		{
			foreach (var actor in _actors.GetEntities())
			{
				actor.Replace<ActiveFace, int>(actor.Get<PredefinedNextSide>().Value);
				actor.Remove<PredefinedNextSide>();
			}

			// foreach (var face in actor.GetDependants().WhereHas<Face>())
			// {
			// 	if (face.Get<Face>().Value == actor.Get<PredefinedNextSide>().Value)
			// 		face.MarkAsActive();
			// }
		}
	}
}