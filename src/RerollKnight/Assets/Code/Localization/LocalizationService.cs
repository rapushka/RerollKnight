using System;
using UnityEngine.Localization.Settings;

namespace Code
{
	public interface ILocalizationService
	{
		LocaleKey[] Locales             { get; }
		LocaleKey   CurrentLocalization { get; }

		string GetLocalized(string table, string key, params object[] arguments);

		void SelectLocalization(LocaleKey key);
	}

	public class LocalizationService : ILocalizationService
	{
		public LocaleKey[] Locales => (LocaleKey[])Enum.GetValues(typeof(LocaleKey));

		public LocaleKey CurrentLocalization => Locales[IndexOfCurrentLocale];

		public int IndexOfCurrentLocale => LocalizationSettings.AvailableLocales.Locales
		                                                       .IndexOf(LocalizationSettings.SelectedLocale);

		public string GetLocalized(string table, string key, params object[] arguments)
			=> LocalizationSettings.StringDatabase.GetLocalizedString
			(
				table,
				key,
				locale: null,
				FallbackBehavior.UseProjectSettings,
				arguments
			);

		public void SelectLocalization(LocaleKey key)
			=> LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[(int)key];
	}
}