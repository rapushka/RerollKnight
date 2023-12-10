using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public class ReadyOnConditionSystemBase : IInitializeSystem, ITearDownSystem
	{
		private readonly Contexts _contexts;

		protected Entity<InfrastructureScope> ReadinessEntity;

		protected ReadyOnConditionSystemBase(Contexts contexts) => _contexts = contexts;

		protected bool Ready
		{
			get => ReadinessEntity.Get<Ready>().Value;
			set => ReadinessEntity.Replace<Ready, bool>(value);
		}

		public virtual void Initialize()
		{
			ReadinessEntity = _contexts.Get<InfrastructureScope>().CreateEntity();
			Ready = false;
		}

		public virtual void TearDown()
		{
			ReadinessEntity.Destroy();
		}
	}
}