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
			=> _entities.PickRandomOrDefault()?.Pick();
	}

	public class PickRandom<T1, T2> : IInitializeSystem
		where T1 : IComponent, new()
		where T2 : IComponent, new()
	{
		private readonly IGroup<Entity<GameScope>> _entities;

		public PickRandom(Contexts contexts)
			=> _entities = contexts.GetGroup(AllOf(Get<T1>(), Get<T2>()));

		public void Initialize()
			=> _entities.PickRandomOrDefault()?.Pick();
	}
}