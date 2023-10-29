using Entitas;

namespace Code
{
	public abstract class FulfillRequestSystemBase : IExecuteSystem
	{
		private readonly IGroup<RequestEntity> _requests;

		protected FulfillRequestSystemBase(Contexts contexts)
		{
			// ReSharper disable once VirtualMemberCallInConstructor - Request must be a simple matcher
			_requests = contexts.request.GetGroup(Request);
		}

		protected abstract IMatcher<RequestEntity> Request { get; }

		public void Execute()
		{
			foreach (var request in _requests)
				OnRequest(request);
		}

		protected abstract void OnRequest(RequestEntity request);
	}
}