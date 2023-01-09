using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code
{
	public class ValueComponent<T> : IComponent
	{
		public T Value { get; set; }
	}
}