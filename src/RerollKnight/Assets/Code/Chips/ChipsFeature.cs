namespace Code
{
	public sealed class ChipsFeature : Feature
	{
		public ChipsFeature(Contexts contexts)
			: base(nameof(ChipsFeature))
		{
			Add(new ChipsPickingFeature(contexts));
			Add(new TargetPickingFeature(contexts));

			Add(new MarkAbilitiesCastedBySystem(contexts));

			Add(new AbilitiesFeature(contexts));

			Add(new EndTurnSystem(contexts));
			// Add(new UnpickAllOnTurnEndedSystem(contexts));
		}
	}
}