using Entitas;

namespace Code
{
	public class ValueComponent<T> : IComponent
	{
		public T Value;

		public static implicit operator T(ValueComponent<T> component) => component.Value;

		public static implicit operator string(ValueComponent<T> component) => component.Value.ToString();
	}
}