public partial class GameEntity
{
	public override string ToString() => hasDebugName ? $"{creationIndex}_{debugName.Value}" : base.ToString();
}