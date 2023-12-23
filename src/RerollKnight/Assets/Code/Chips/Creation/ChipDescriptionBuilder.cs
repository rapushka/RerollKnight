namespace Code
{
	public class ChipDescriptionBuilder
	{
		public string Build(ChipConfigBehaviour config) => config.DescriptionKey.GetLocalizedString();
	}
}