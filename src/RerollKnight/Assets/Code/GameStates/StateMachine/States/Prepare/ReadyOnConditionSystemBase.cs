using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public class ReadyOnConditionSystemBase : IInitializeSystem, ITearDownSystem
	{
		private readonly Contexts _contexts;

		private Entity<InfrastructureScope> _readinessEntity;

		protected ReadyOnConditionSystemBase(Contexts contexts) => _contexts = contexts;

		protected bool Ready
		{
			get => _readinessEntity.Get<Ready>().Value;
			set => _readinessEntity.Replace<Ready, bool>(value);
		}

		public virtual void Initialize()
		{
			_readinessEntity = _contexts.Get<InfrastructureScope>().CreateEntity();
			Ready = false;
		}

		public virtual void TearDown()
		{
			_readinessEntity.Destroy();
		}
	}
}