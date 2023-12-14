using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class DestroyDoorsSystem : ITearDownSystem
	{
		private readonly IGroup<Entity<GameScope>> _doors;

		public DestroyDoorsSystem(Contexts contexts)
			=> _doors = contexts.GetGroup(ScopeMatcher<GameScope>.Get<DoorTo>());

		public void TearDown()
		{
			foreach (var door in _doors)
				door.Is<Destroyed>(true);
		}
	}
}