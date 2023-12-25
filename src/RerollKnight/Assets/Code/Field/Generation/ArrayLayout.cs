using System;

namespace Code
{
	[Serializable]
	public class ArrayLayout<T>
	{
		public Row[] Rows = new Row[Constants.RoomSizes];

		public T this[int i, int j]
		{
			get => Rows[i][j];
			set => Rows[i][j] = value;
		}

		public T[,] ToSquareArray()
		{
			var xLength = Rows.Length;
			var yLength = Rows[0].Value.Length;
			var result = new T[xLength, yLength];

			for (var i = 0; i < Constants.RoomSizes; i++)
			for (var j = 0; j < Constants.RoomSizes; j++)
			{
				result[i, j] = Rows[i].Value[j];
			}

			return result;
		}

		public static implicit operator T[,](ArrayLayout<T> @this) => @this.ToSquareArray();

		[Serializable]
		public class Row
		{
			public T[] Value = new T[Constants.RoomSizes];

			public T this[int i]
			{
				get => Value[i];
				set => Value[i] = value;
			}
		}
	}
}