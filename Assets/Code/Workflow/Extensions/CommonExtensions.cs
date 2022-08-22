using System;

namespace Code.Workflow.Extensions
{
	public static class CommonExtensions
	{
		public static T Do<T>(this T @this, Action<T> action, bool @if)
		{
			if (@if)
			{
				action.Invoke(@this);
			}

			return @this;
		}

		public static T Do<T>(this T @this, Action<T> action)
		{
			action.Invoke(@this);
			return @this;
		}
	}
}