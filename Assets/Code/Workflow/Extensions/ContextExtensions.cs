using Entitas;

namespace Code.Workflow.Extensions
{
	public static class ContextExtensions
	{
		public static IGroup<T> GetAllOf<T>(this Context<T> @this, params IMatcher<T>[] matchers)
			where T : class, IEntity
			=> @this.GetGroup(Matcher<T>.AllOf(matchers));
	}
}