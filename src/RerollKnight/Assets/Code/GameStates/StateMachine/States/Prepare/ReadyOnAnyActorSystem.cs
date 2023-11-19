using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class ReadyOnAny<T> : ReadyOnConditionSystemBase, IExecuteSystem
		where T : IComponent, new()
	{
		private readonly IGroup<Entity<GameScope>> _entities;

		public ReadyOnAny(Contexts contexts) : base(contexts)
			=> _entities = contexts.GetGroup(ScopeMatcher<GameScope>.Get<T>());

		public void Execute()
		{
			Ready = _entities.Any();
		}
	}
}