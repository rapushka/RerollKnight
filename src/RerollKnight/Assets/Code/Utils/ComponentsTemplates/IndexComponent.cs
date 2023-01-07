using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code
{
	public class IndexComponent<T> : IComponent
	{
		[EntityIndex] public T Value { get; set; }
	}
}