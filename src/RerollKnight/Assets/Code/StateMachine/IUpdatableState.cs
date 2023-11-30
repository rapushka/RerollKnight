namespace Code
{
	public interface IUpdatableState
	{
		void Execute();
		void Cleanup();
	}
}