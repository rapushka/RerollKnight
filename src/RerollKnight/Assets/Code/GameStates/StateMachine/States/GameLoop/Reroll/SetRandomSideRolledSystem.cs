using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class SetRandomSideRolledSystem : ITearDownSystem
	{
		private readonly TurnsQueue _turnsQueue;
		private readonly IGroup<Entity<GameScope>> _actors;

		[Inject]
		public SetRandomSideRolledSystem(Contexts contexts)
			=> _actors = contexts.GetGroup(AllOf(Get<Actor>()).NoneOf(Get<PredefinedNextSide>()));

		public void TearDown()
		{
			foreach (var actor in _actors.GetEntities())
				actor.PredefineRandomSide();
		}
	}
}