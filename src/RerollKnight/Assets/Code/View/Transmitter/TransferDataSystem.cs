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
			_entities = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Transmitter>());
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				foreach (var transmitter in e.Get<Transmitter>().Value)
					transmitter.Transfer();
			}
		}
	}
}