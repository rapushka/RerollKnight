namespace Code
{
	public interface IRange<T>
	{
		public T Min { get; set; }
		public T Max { get; set; }

		T Delta { get; }
	}
}