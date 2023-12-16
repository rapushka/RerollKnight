using UnityEngine;

namespace Code
{
	public interface IStorageService
	{
		LocaleKey  Localization { get; set; }
		bool       IsFullscreen { get; set; }
		Resolution Resolution   { get; set; }
	}

	public class PlayerPrefsStorage : IStorageService
	{
		private const int True = 1;
		private const int False = 0;

		public LocaleKey Localization
		{
			get => (LocaleKey)PlayerPrefs.GetInt("Settings.Localization", (int)LocaleKey.English);
			set => PlayerPrefs.SetInt("Settings.Localization", (int)value);
		}

		public bool IsFullscreen
		{
			get => PlayerPrefs.GetInt("Settings.IsFullscreen", True) == True;
			set => PlayerPrefs.SetInt("Settings.IsFullscreen", value ? True : False);
		}

		public Resolution Resolution
		{
			get => new() { width = ScreenWidth, height = ScreenHeight };
			set
			{
				ScreenWidth = value.width;
				ScreenHeight = value.height;
			}
		}

		private int ScreenWidth
		{
			get => PlayerPrefs.GetInt("Settings.Resolution.Width", 1920);
			set => PlayerPrefs.SetInt("Settings.Resolution.Width", value);
		}

		private int ScreenHeight
		{
			get => PlayerPrefs.GetInt("Settings.Resolution.Height", 1080);
			set => PlayerPrefs.SetInt("Settings.Resolution.Height", value);
		}
	}
}