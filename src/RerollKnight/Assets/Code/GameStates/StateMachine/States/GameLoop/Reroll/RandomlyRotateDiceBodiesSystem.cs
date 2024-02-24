using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class RandomlyRotateDiceBodiesSystem : IInitializeSystem, ITearDownSystem
	{
		private readonly IGroup<Entity<GameScope>> _entities;

		public RandomlyRotateDiceBodiesSystem(Contexts contexts)
			=> _entities = contexts.GetGroup(ScopeMatcher<GameScope>.Get<DiceBody>());

		public void Initialize()
		{
			foreach (var e in _entities)
				e.Is<RandomlyRotating>(true);
		}

		public void TearDown()
		{
			foreach (var e in _entities)
				e.Is<RandomlyRotating>(false);
		}
	}
}