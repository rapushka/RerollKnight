using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code
{
	public class PrimaryComponent<T> : IComponent
	{
		[PrimaryEntityIndex] public T Value;
	}
}
