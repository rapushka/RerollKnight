using Entitas;

namespace Code
{
	// TODO: omfg
	public static class RequestRerollDirtyFlag
	{
		public static bool IsNeeded { get; set; }
	}

	public class SetRerollNeededSystem : IInitializeSystem
	{
		public void Initialize()
		{
			RequestRerollDirtyFlag.IsNeeded = true;
		}
	}
}