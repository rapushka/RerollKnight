namespace Code
{
	public interface IDataReceiver<in T>
	{
		void SetData(T value);
	}
}