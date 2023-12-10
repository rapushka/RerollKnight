using UnityEngine;

namespace Code
{
	/// <summary> For determinism 🤓 </summary>
	public class RandomService
	{
		private System.Random _random = new();
		private static RandomService _instance;

		public static RandomService Instance => _instance ??= new RandomService();

		public void SetSeed(int seed) => _random = new System.Random(seed);

		public int Range(int minInclusive, int maxExclusive)
			=> _random.Next(minInclusive, maxExclusive);

		public int RangeInclusive(RangeInt range)
			=> _random.Next(range.Min, range.Max);

		public Quaternion Rotation()
			=> Quaternion.Euler
			(
				_random.Next(0, 360),
				_random.Next(0, 360),
				_random.Next(0, 360)
			);
	}
}