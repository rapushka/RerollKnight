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

		public static T Do<T>(this T @this, Action<T> action, Func<T, bool> @if)
		{
			if (@if.Invoke(@this))
			{
				action.Invoke(@this);
			}

			return @this;
		}
		public static T Do<T>(this T @this, Func<T, bool> @if, Action<T> @do, Action<T> elseDo)
		{
			if (@if.Invoke(@this))
			{
				@do.Invoke(@this);
			}
			else
			{
				elseDo.Invoke(@this);
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