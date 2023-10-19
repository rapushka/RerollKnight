namespace Code
{
	public static class EntityIndexExtensions
	{
		public static bool HasEntityWithCoordinates(this GameContext @this, Coordinates coordinates)
			=> @this.GetEntityWithCoordinates(coordinates) is not null;
	}
}