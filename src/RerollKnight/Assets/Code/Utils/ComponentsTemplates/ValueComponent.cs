using Entitas;

namespace Code
{
	public class ValueComponent<T> : IComponent
	{
		public T Value { get; set; }
	}
}