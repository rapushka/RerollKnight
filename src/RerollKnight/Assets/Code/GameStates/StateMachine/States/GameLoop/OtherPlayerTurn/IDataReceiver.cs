namespace Code
{
	public interface IDataReceiver<in T>
	{
		public void SetData(T value)
			=> Value = value;

		T Value { set; }
	}
}