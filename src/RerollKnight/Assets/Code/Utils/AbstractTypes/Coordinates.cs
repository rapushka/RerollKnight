using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public struct Coordinates
	{
		[SerializeField] private int _column;
		[SerializeField] private int _row;

		public int Column => _column;
		public int Row    => _row;

		public Coordinates(Vector3 vector)
		{
			_column = (int)vector.x;
			_row = (int)vector.y;
		}
	}
}