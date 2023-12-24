using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
	public static class WeightyRandomExtensions
	{
		public static T PickRandomWithRarity<T>(this IEnumerable<T> @this)
			where T : IRarityEntry
		{
			var list = @this.ToList();

			if (@this == null || !list.Any())
				throw new ArgumentException("Collection is empty or null.");

			var totalRaritySum = list.Sum(item => item.Rarity);
			var randomValue = RandomService.Instance.Next() * totalRaritySum;

			foreach (var item in list)
			{
				randomValue -= item.Rarity;

				if (randomValue < 0)
					return item;
			}

			throw new InvalidOperationException("No item found with matching rarity.");
		}
	}
}