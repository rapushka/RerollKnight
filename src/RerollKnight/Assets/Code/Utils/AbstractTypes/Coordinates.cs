using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class Coordinates
	{
		[field: SerializeField] public int Column { get; private set; }
		[field: SerializeField] public int Row    { get; private set; }

		public Coordinates(Vector2 vector)
		{
			Column = (int)vector.x;
			Row = (int)vector.y;
		}

		public Coordinates(int column, int row)
		{
			Column = column;
			Row = row;
		}

		public Vector3 ToTopDown() => ((Vector2)this).ToTopDown();

		public static explicit operator Vector2(Coordinates coordinates)
			=> new(coordinates.Column, coordinates.Row);
	}
}