using Entitas;

namespace Code
{
	public sealed class InvokeAllStoredRequestsSystem : IExecuteSystem
	{
		public void Execute() => RequestHandler.Instance.InvokeAll();
	}
}