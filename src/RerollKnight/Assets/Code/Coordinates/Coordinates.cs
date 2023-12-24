using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class Coordinates
	{
		public enum Layer
		{
			/// <summary> For disabled entities, Equals always will return false </summary>
			None,
			/// <summary> Standing on cell, e.g Player/Enemy/Wall </summary>
			Default,
			/// <summary> For cells itself </summary>
			Bellow,
			/// <summary> Where the room on the level </summary>
			Room,
			/// <summary> e.g Click at some coordinates </summary>
			Request,
			/// <summary> Layer will be ignored on Equals </summary>
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

		public static Coordinates Zero => new(0, 0);

		public Vector3 ToTopDown() => ((Vector2)this).ToTopDown();

		public Coordinates WithLayer(Layer layer)
			=> new(Column, Row, layer);

		public Coordinates WithColumn(int value)
			=> new(value, Row, OnLayer);

		public Coordinates WithRow(int value)
			=> new(Column, value, OnLayer);

		public Coordinates Add(int column = 0, int row = 0)
			=> new(Column + column, Row + row, OnLayer);

		public Coordinates Normalize()
			=> new(Column.Clamp(min: -1, max: 1), Row.Clamp(min: -1, max: 1), OnLayer);

		public static explicit operator Vector2(Coordinates coordinates)
			=> new(coordinates.Column, coordinates.Row);

		public static explicit operator Coordinates(Vector2 vector)
			=> new(vector);

		public static Coordinates operator +(Coordinates left, Coordinates right)
			=> left.Add(column: right.Column, row: right.Row);

		public static Coordinates operator *(Coordinates source, int multiplier)
			=> new(source.Column * multiplier, source.Row * multiplier, source.OnLayer);

		public static Coordinates operator *(int multiplier, Coordinates source)
			=> new(source.Column * multiplier, source.Row * multiplier, source.OnLayer);

		public static bool operator ==(Coordinates left, Coordinates right)
			=> left?.Equals(right) ?? false;

		public static bool operator !=(Coordinates left, Coordinates right) => !(left == right);

		public static Coordinates operator -(Coordinates left, Coordinates right)
			=> new(left.Column - right.Column, left.Row - right.Row, Layer.Ignore);

		public static bool operator ==(Coordinates left, (int, int) right)
			=> left is not null && left.Column == right.Item1 && left.Row == right.Item2;

		public static bool operator ==((int, int) left, Coordinates right)
			=> right is not null && right.Column == left.Item1 && right.Row == left.Item2;

		public static bool operator !=(Coordinates left, (int, int) right) => !(left == right);

		public static bool operator !=((int, int) right, Coordinates left) => !(right == left);

		public override bool Equals(object obj) => obj is Coordinates coordinates
		                                           && Equals(coordinates);

		protected bool Equals(Coordinates other)
			=> !IsOnLayerNone(other)
			   && Column == other.Column
			   && Row == other.Row
			   && (OnLayer == other.OnLayer || IgnoreLayer(other));

		private bool IsOnLayerNone(Coordinates other) => OnLayer is Layer.None || other.OnLayer is Layer.None;

		private bool IgnoreLayer(Coordinates other) => OnLayer is Layer.Ignore || other.OnLayer is Layer.Ignore;

		// ReSharper disable NonReadonlyMemberInGetHashCode – needed fo view in the inspector

		public override int GetHashCode() => HashCode.Combine(Column, Row, OnLayer);

		public override string ToString() => $"({OnLayer.ToString()})–[{Column}; {Row}]";

		public string ToShortString() => $"({Column}; {Row})";
	}
}