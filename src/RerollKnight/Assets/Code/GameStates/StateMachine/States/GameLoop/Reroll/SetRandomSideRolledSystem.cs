using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class SetRandomSideRolledSystem : ITearDownSystem
	{
		private readonly TurnsQueue _turnsQueue;
		private readonly IGroup<Entity<GameScope>> _actors;

		[Inject]
		public SetRandomSideRolledSystem(Contexts contexts)
			=> _actors = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Actor>());

		public void TearDown()
		{
			foreach (var actor in _actors)
			{
				var randomFace = actor.GetDependants().WhereHas<Face>().PickRandom();
				randomFace.MarkAsActive();
			}
		}
	}
}