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

		public Coordinates(Vector2 vector)
		{
			_column = (int)vector.x;
			_row = (int)vector.y;
		}

		public Vector3 ToTopDown() => ((Vector2)this).ToTopDown();

		public static explicit operator Vector2(Coordinates coordinates)
			=> new(coordinates.Column, coordinates.Row);
	}
}