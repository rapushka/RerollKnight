using UnityEngine.Localization.Settings;

namespace Code
{
	public interface ILocalizationService
	{
		string GetLocalized(string key, params object[] arguments);
	}

	public class LocalizationService : ILocalizationService
	{
		public string GetLocalized(string key, params object[] arguments)
			=> LocalizationSettings.StringDatabase.GetLocalizedString
			(
				"Game",
				key,
				locale: null,
				FallbackBehavior.UseProjectSettings,
				arguments
			);
	}
}