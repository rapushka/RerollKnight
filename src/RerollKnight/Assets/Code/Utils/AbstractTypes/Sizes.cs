using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public struct Sizes
	{
		[SerializeField] private int _width;
		[SerializeField] private int _height;

		public int Width  => _width;
		public int Height => _height;

		public Sizes(Vector3 vector)
		{
			_width = (int)vector.x;
			_height = (int)vector.y;
		}
	}
}