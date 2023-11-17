using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class ReadyOnPlayerSpawnedSystem : IInitializeSystem, IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _entities;
		private readonly Contexts _contexts;

		private Entity<InfrastructureScope> _readiness;

		public ReadyOnPlayerSpawnedSystem(Contexts contexts)
		{
			_contexts = contexts;
			_entities = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Player>());
		}

		private bool Ready { set => _readiness.Replace<Ready, bool>(value); }

		public void Initialize()
		{
			_readiness = _contexts.Get<InfrastructureScope>().CreateEntity();
			Ready = false;
		}

		public void Execute()
		{
			Ready = _entities.Any();
		}
	}
}