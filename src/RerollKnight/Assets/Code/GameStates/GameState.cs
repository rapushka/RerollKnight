namespace Code
{
	public enum GameState
	{
		NotInGame,
		PickingChip, // Observing
		PickingTarget, // ChipPicked
		WaitingForAbilityUsage, // Waiting
		WaitingForEnemiesMoves,
		TurnEnded, // TurnEnded
	}
}