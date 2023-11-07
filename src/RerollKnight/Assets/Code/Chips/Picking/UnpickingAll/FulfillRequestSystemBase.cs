using Entitas;
using Entitas.Generic;

namespace Code
{
	public abstract class FulfillRequestSystemBase : IExecuteSystem
	{
		private readonly IGroup<Entity<RequestScope>> _requests;

		protected FulfillRequestSystemBase(Contexts contexts)
		{
			// ReSharper disable once VirtualMemberCallInConstructor - Request must be a simple matcher
			_requests = contexts.Get<RequestScope>().GetGroup(Request);
		}

		protected abstract IMatcher<Entity<RequestScope>> Request { get; }

		public void Execute()
		{
			foreach (var request in _requests)
				OnRequest(request);
		}

		protected abstract void OnRequest(Entity<RequestScope> request);
	}
}