using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.WorkFlow.ComponentsTemplates
{
	public sealed class IndexComponent<T> : IComponent
	{
		[EntityIndex] public T Value;

		public static implicit operator T(IndexComponent<T> component)
			=> component.Value;

		public static implicit operator string(IndexComponent<T> component)
			=> component.Value.ToString();
	}
}
