namespace Code
{
	public static class CellExtensions
	{
		private static readonly GameContext _context = Contexts.sharedInstance.game;

		public static bool IsOccupied(this GameEntity @this)
		{
			var cellCoordinates = @this.GetCoordinates();
			return _context.HasEntityWithCoordinates(cellCoordinates);
		}

		public static bool IsEmpty(this GameEntity @this)
		{
			return !@this.IsOccupied();
		}
	}
}