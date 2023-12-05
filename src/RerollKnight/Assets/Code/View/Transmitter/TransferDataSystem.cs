using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class TransferDataSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _entities;

		public TransferDataSystem(Contexts contexts)
		{
			_entities = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Transport>());
		}

		public void Execute()
		{
			foreach (var e in _entities)
			foreach (var transport in e.Get<Transport>().Value)
				transport.Transfer();
		}
	}
}