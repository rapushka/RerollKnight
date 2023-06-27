namespace Code
{
	public static class PickingExtensions
	{
		public static void Pick(this GameEntity @this) => @this.isPickedChip = true;

		public static void Unpick(this GameEntity @this) => @this.isPickedChip = false;
	}
}