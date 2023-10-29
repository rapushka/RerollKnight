namespace Code
{
	public static class PickingExtensions
	{
		public static void Pick(this GameEntity @this) => @this.SetPicking(true);

		public static void Unpick(this GameEntity @this) => @this.SetPicking(false);

		private static void SetPicking(this GameEntity @this, bool value)
		{
			if (@this.isChip)
				@this.isPickedChip = value;
			else
				@this.isPickedTarget = value;
		}
	}
}