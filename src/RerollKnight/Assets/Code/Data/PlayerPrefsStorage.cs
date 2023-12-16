using UnityEngine;

namespace Code
{
	public interface IStorageService
	{
		LocaleKey Localization { get; set; }
	}

	public class PlayerPrefsStorage : IStorageService
	{
		public LocaleKey Localization
		{
			get => (LocaleKey)PlayerPrefs.GetInt("Settings.Localization", (int)LocaleKey.English);
			set => PlayerPrefs.SetInt("Settings.Localization", (int)value);
		}
	}
}