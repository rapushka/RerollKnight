using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class WallsLayout
	{
		[SerializeField] private ArrayLayout<bool> _walls = new();

		public bool[,] Walls => _walls;

		public bool CanBeFirst => _walls[0, 0] == false;
	}
}