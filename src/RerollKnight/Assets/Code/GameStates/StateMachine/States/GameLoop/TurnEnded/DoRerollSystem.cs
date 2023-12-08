using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class DoRerollSystem : IInitializeSystem
	{
		private readonly TurnsQueue _turnsQueue;
		private readonly IGroup<Entity<GameScope>> _actors;

		[Inject]
		public DoRerollSystem(Contexts contexts, TurnsQueue turnsQueue)
		{
			_turnsQueue = turnsQueue;

			_actors = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Actor>());
		}

		public void Initialize()
		{
			if (!_turnsQueue.CurrentIsFirst)
				return;

			foreach (var actor in _actors)
			{
				var randomFace = actor.GetDependants().WhereHas<Face>().PickRandom();
				randomFace.MarkAsActive();
			}
		}
	}
}