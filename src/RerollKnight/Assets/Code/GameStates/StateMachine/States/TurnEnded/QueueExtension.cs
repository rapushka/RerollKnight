using System.Collections.Generic;

namespace Code
{
	public static class QueueExtension
	{
		public static void EnqueueRange<T>(this Queue<T> @this, IEnumerable<T> other)
		{
			foreach (var item in other)
				@this.Enqueue(item);
		}
	}
}