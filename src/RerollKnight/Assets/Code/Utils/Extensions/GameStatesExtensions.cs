namespace Code
{
	public static class GameStatesExtensions
	{
		public static void ToGameState(this Contexts @this, GameState state) => @this.game.ReplaceGameState(state);
	}
}