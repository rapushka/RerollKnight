using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public class SettingsWindow : WindowBase
	{
		[Header("General")]
		[SerializeField] private LocalizationSelector _localizationSelector;

// ReSharper disable NotAccessedField.Local
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
			_localizationSelector.Fill(_localizationService.Locales);
			_localizationSelector.Selected = _localizationService.CurrentLocalization;
			// OnLocalizationSelected(_localizationService.CurrentLocalization);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_localizationSelector.OptionSelected += OnLocalizationSelected;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			_localizationSelector.OptionSelected -= OnLocalizationSelected;
		}

		private void OnLocalizationSelected(LocaleKey localeKey)
			=> _localizationService.SelectLocalization(localeKey);
	}
}