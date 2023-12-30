using JetBrains.Annotations;

namespace Code
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)] // Used From Editor
	public enum Sound
	{
		None,

		// General
		ChipClick,
		DicesThrow,
		DicesLand,

		// Abilities
		Kick,
		Shoot,
		Spit,
		Step,
		Teleport,

		// UI
	}
}