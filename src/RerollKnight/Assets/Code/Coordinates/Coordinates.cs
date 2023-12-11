using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class Coordinates
	{
		public enum Layer
		{
			/// <summary> For disabled entities, Won't compare </summary>
			None,
			/// <summary> Standing on cell, e.g Player/Enemy/Wall </summary>
			Default,
			/// <summary> For cells itself </summary>
			Bellow,
			/// <summary> Where the room on the level </summary>
			Room,
			/// <summary> e.g Click at some coordinates </summary>
			Request,
			/// <summary> For coordinates, where layer doesn't matter </summary>
			Ignore,
		}

		[field: SerializeField] public int   Column  { get; private set; }
		[field: SerializeField] public int   Row     { get; private set; }
		[field: SerializeField] public Layer OnLayer { get; private set; }

		public Coordinates(Vector2 vector)
			: this((int)vector.x, (int)vector.y) { }

		public Coordinates(int column, int row, Layer layer = Layer.None)
		{
			Column = column;
			Row = row;
			OnLayer = layer;
		}

		public Vector3 ToTopDown() => ((Vector2)this).ToTopDown();

		public int DistanceTo(Coordinates other) => Mathf.Max(Column.Delta(other.Column), Row.Delta(other.Row));

		public Coordinates WithLayer(Layer layer)
			=> new(Column, Row, layer);

		public Coordinates WithColumn(int value)
			=> new(value, Row, OnLayer);

		public Coordinates WithRow(int value)
			=> new(Column, value, OnLayer);

		public Coordinates Add(int column = 0, int row = 0)
			=> new(Column + column, Row + row);

		protected bool Equals(Coordinates other)
			=> !IsBothNone(other)
			   && Column == other.Column
			   && Row == other.Row
			   && OnLayer == other.OnLayer;

		private bool IsBothNone(Coordinates other) => OnLayer is Layer.None && other.OnLayer is Layer.None;

		public static explicit operator Vector2(Coordinates coordinates)
			=> new(coordinates.Column, coordinates.Row);

		public override bool Equals(object obj) => obj is Coordinates coordinates
		                                           && Equals(coordinates);

		// ReSharper disable NonReadonlyMemberInGetHashCode – needed fo view in the inspector
		public override int GetHashCode() => HashCode.Combine(Column, Row, OnLayer);

		public override string ToString() => $"({OnLayer.ToString()})–[{Column}; {Row}]";
	}
}