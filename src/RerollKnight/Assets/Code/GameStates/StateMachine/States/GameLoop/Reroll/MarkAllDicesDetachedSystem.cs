using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class MarkAllDicesDetachedSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<GameScope>> _dices;

		public MarkAllDicesDetachedSystem(Contexts contexts)
		{
			_dices = contexts.GetGroup(Get<Actor>());
		}

		public void Initialize()
		{
			foreach (var e in _dices)
				e.Is<Detached>(true);
		}
	}
}