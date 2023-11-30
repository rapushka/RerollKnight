using System.Collections.Generic;
using System.Linq;

namespace Code
{
	/// <summary> Extensions for list, those make it more like queue </summary>
	public static class QueueLikeExtension
	{
		public static bool TryDequeue<T>(this List<T> @this, out T result)
		{
			result = @this.FirstOrDefault();
			var hasAny = result is not null;

			if (hasAny)
				@this.RemoveAt(0);

			return hasAny;
		}

		public static T Dequeue<T>(this List<T> @this)
		{
			var first = @this.First();
			@this.RemoveAt(0);

			return first;
		}

		public static void Enqueue<T>(this List<T> @this, T item)
		{
			@this.Insert(0, item);
		}
	}
}