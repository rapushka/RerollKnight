using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class ReadyOnAnyActorSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _actors;
		private readonly Contexts _contexts;

		private Entity<InfrastructureScope> _readiness;

		public ReadyOnAnyActorSystem(Contexts contexts)
		{
			_contexts = contexts;
			_actors = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Actor>());
		}

		private bool Ready { set => _readiness.Replace<Ready, bool>(value); }

		public void Initialize()
		{
			_readiness = _contexts.Get<InfrastructureScope>().CreateEntity();
			Ready = false;
		}

		public void Execute()
		{
			Ready = _actors.Any();
		}
	}
}