namespace Code
{
	public static class ChipAbilityExtensions
	{
		public static bool IsOwnedBy(this ChipsEntity @this, GameEntity chip)
			=> @this.abilityOfChip.Value == chip;
	}
}