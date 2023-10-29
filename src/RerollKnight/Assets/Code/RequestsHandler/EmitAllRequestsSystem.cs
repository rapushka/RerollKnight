using Entitas;

namespace Code
{
	public sealed class EmitAllRequestsSystem : IExecuteSystem
	{
		public void Execute() => RequestEmitter.Instance.EmitAll();
	}
}