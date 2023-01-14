using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code
{
	public class PrimaryComponent<T> : IComponent
	{
		[PrimaryEntityIndex] public T Value;

		public static implicit operator T(PrimaryComponent<T> component) => component.Value;

		public static implicit operator string(PrimaryComponent<T> component) => component.Value.ToString();
	}
}