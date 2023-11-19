using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class ReadyOnAnyActorSystem : ReadyOnConditionSystemBase, IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _actors;

		public ReadyOnAnyActorSystem(Contexts contexts) : base(contexts)
			=> _actors = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Actor>());

		public void Execute()
		{
			Ready = _actors.Any();
		}
	}
}