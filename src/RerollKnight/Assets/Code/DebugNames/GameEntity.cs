public partial class GameEntity
{
	public override string ToString() => hasDebugName ? debugName.Value : base.ToString();
}