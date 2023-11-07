// public partial class Entity<TScope> : Entity
// 	where TScope : IScope
// {
// 	private const string Space = " ";
//
// 	public override string ToString() => string.Join(Space, Strings);
//
// 	private string[] Strings => new[]
// 	{
// 		creationIndex.ToString(),
// 		DebugName,
// 		Coordinates,
// 		Picked,
// 		Available,
// 	};
//
// 	private string DebugName => hasDebugName ? debugName.Value : "e";
//
// 	private string Coordinates => hasCoordinates ? coordinates.Value.ToString() : string.Empty;
//
// 	private string Picked => isPickedChip || isPickedTarget ? "<- picked" : string.Empty;
//
// 	private string Available => isAvailableToPick ? "available" : string.Empty;
// }
