namespace Code
{
	public static class GameStatesExtensions
	{
		public static void ToGameState(this Contexts @this, GameState state) => @this.game.ReplaceGameState(state);
		public static bool GameStateIs(this Contexts @this, GameState state) => @this.game.gameState.Value == state;

		public static void TransferGameState(this Contexts @this, GameState from, GameState to)
		{
			if (@this.GameStateIs(from))
				@this.ToGameState(to);
		}
	}
}