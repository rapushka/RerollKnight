using Entitas;
using Entitas.Generic;
using RequestMatcher = Entitas.Generic.ScopeMatcher<Code.RequestScope>;

namespace Code
{
	public abstract class FulfillRequestSystemBase<TComponent> : IExecuteSystem
		where TComponent : IComponent, new()
	{
		private readonly IGroup<Entity<RequestScope>> _requests;

		protected FulfillRequestSystemBase(Contexts contexts)
		{
			_requests = contexts.GetGroup(RequestMatcher.Get<TComponent>());
		}

		public void Execute()
		{
			foreach (var request in _requests)
				OnRequest(request);
		}

		protected abstract void OnRequest(Entity<RequestScope> request);
	}
}