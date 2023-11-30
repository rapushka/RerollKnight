using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class PickRandom<T> : IInitializeSystem
		where T : IComponent, new()
	{
		private readonly IGroup<Entity<GameScope>> _entities;

		public PickRandom(Contexts contexts)
			=> _entities = contexts.GetGroup(Get<T>());

		public void Initialize()
			=> _entities.PickRandom().Pick();
	}
}