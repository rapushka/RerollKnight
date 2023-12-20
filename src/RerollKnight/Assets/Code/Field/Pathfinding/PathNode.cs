namespace Code
{
	public class PathNode
	{
		public PathNode(Coordinates coordinates) => Coordinates = coordinates;

		public Coordinates Coordinates { get; }

		public int FCost => GCost + HCost;

		public int GCost { get; set; } = int.MaxValue; // TODO: mb -1? :(
		public int HCost { get; set; }

		public PathNode PreviousNode { get; set; }

		public static implicit operator Coordinates(PathNode @this) => @this.Coordinates;

		public override string ToString() => $"node: {Coordinates.ToShortString()}";
	}
}