public partial class GameEntity
{
	private const string Space = " ";

	public override string ToString() => string.Join(Space, Strings);

	private string[] Strings => new[] { creationIndex.ToString(), DebugName, Coordinates, Picked, };

	private string DebugName => hasDebugName ? debugName.Value : base.ToString();

	private string Coordinates => hasCoordinates ? coordinates.Value.ToString() : string.Empty;

	private string Picked => isPickedChip || isPickedTarget ? "<- picked" : string.Empty;
}