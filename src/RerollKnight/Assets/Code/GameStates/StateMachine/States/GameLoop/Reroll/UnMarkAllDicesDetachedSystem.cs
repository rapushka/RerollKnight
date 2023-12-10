using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class UnMarkAllDicesDetachedSystem : ITearDownSystem
	{
		private readonly IGroup<Entity<GameScope>> _dices;

		public UnMarkAllDicesDetachedSystem(Contexts contexts)
		{
			_dices = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Actor>());
		}

		public void TearDown()
		{
			foreach (var e in _dices)
				e.Is<Detached>(true);
		}
	}
}