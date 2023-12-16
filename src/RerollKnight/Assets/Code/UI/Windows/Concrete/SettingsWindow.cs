using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public class SettingsWindow : WindowBase
	{
		[Header("General")]
		[SerializeField] private LocalizationSelector _localizationSelector;

		[Header("Video Settings")]
		[SerializeField] private Toggle _fullscreenToggle;
		[SerializeField] private ResolutionSelector _resolutionSelector;

// ReSharper disable NotAccessedField.Local
		[Header("Audio Settings")]
		[SerializeField] private Slider _musicVolumeSlider;
		[SerializeField] private Slider _soundsVolumeSlider;

		private ILocalizationService _localizationService;
		private IStorageService _storageService;
		private ScreenSettings _screen;

		[Inject]
		public void Construct
		(
			ILocalizationService localizationService,
			IStorageService storageService,
			ScreenSettings screen
		)
		{
			_localizationService = localizationService;
			_storageService = storageService;
			_screen = screen;
		}

		public override void Initialize()
		{
			InitializeLocalization();
			InitializeScreenSettings();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_localizationSelector.OptionSelected += OnLocalizationSelected;
			_resolutionSelector.OptionSelected += OnResolutionSelected;
			_fullscreenToggle.onValueChanged.AddListener(OnFullscreenToggle);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			_localizationSelector.OptionSelected -= OnLocalizationSelected;
			_resolutionSelector.OptionSelected -= OnResolutionSelected;
			_fullscreenToggle.onValueChanged.RemoveListener(OnFullscreenToggle);
		}

		private void InitializeLocalization()
		{
			_localizationSelector.Fill(_localizationService.Locales);
			_localizationSelector.Selected = _storageService.Localization;

			OnLocalizationSelected(_storageService.Localization);
		}

		private void OnLocalizationSelected(LocaleKey localeKey)
		{
			_localizationService.SelectLocalization(localeKey);
			_storageService.Localization = localeKey;
		}

		private void InitializeScreenSettings()
		{
			// _screen.CurrentResolution = _storageService.Resolution;
			// _screen.IsFullscreen = _storageService.IsFullscreen;
			Debug.Log(string.Join("\n", _screen.AvailableResolutions));

			_resolutionSelector.Fill(_screen.AvailableResolutions);
			_resolutionSelector.Selected = _storageService.Resolution;

			_fullscreenToggle.isOn = _screen.IsFullscreen;

			OnResolutionSelected(_storageService.Resolution);
			OnFullscreenToggle(_storageService.IsFullscreen);
		}

		private void OnResolutionSelected(Vector2Int resolution)
		{
			_screen.CurrentResolution = resolution;
			_storageService.Resolution = resolution;
		}

		private void OnFullscreenToggle(bool isOn)
		{
			_screen.IsFullscreen = isOn;
			_storageService.IsFullscreen = isOn;
		}
	}
}