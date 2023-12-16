using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public class SettingsWindow : WindowBase
	{
		[SerializeField] private LocalizationSelector _localizationSelector;

		[Header("Video Settings")]
		[SerializeField] private Toggle _fullScreenToggle;
		[SerializeField] private Selector<Resolution> _resolutionSelector;

		[Header("Audio Settings")]
		[SerializeField] private Slider _musicVolumeSlider;
		[SerializeField] private Slider _soundsVolumeSlider;

		private ILocalizationService _localizationService;

		[Inject]
		public void Construct(ILocalizationService localizationService)
		{
			_localizationService = localizationService;
		}

		public override void Initialize()
		{
			foreach (var locale in _localizationService.Locales)
				Debug.Log($"locale = {locale}");

			_localizationSelector.Fill(_localizationService.Locales);
			_localizationSelector.Selected = _localizationService.CurrentLocalization;
			_localizationSelector.OptionSelected += OnLocalizationSelected;
		}

		private void OnLocalizationSelected(LocaleKey localeKey)
			=> _localizationService.SelectLocalization(localeKey);
	}
}