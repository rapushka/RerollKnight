using UnityEngine;
using UnityEngine.Audio;
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

		[Header("Audio Settings")]
		[SerializeField] private Slider _musicVolumeSlider;
		[SerializeField] private Slider _soundsVolumeSlider;

		private ILocalizationService _localizationService;
		private IStorageService _storageService;
		private ScreenSettings _screen;
		private AudioMixerGroup _audioMixerGroup;

		[Inject]
		public void Construct
		(
			ILocalizationService localizationService,
			IStorageService storageService,
			ScreenSettings screen,
			AudioMixerGroup audioMixerGroup
		)
		{
			_localizationService = localizationService;
			_storageService = storageService;
			_screen = screen;
			_audioMixerGroup = audioMixerGroup;
		}

		public override void Initialize()
		{
			InitializeLocalization();
			InitializeScreenSettings();
			InitializeAudio();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_localizationSelector.OptionSelected += OnLocalizationSelected;
			_resolutionSelector.OptionSelected += OnResolutionSelected;
			_fullscreenToggle.onValueChanged.AddListener(OnFullscreenToggle);
			_musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
			_soundsVolumeSlider.onValueChanged.AddListener(OnSoundsVolumeChanged);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			_localizationSelector.OptionSelected -= OnLocalizationSelected;
			_resolutionSelector.OptionSelected -= OnResolutionSelected;
			_fullscreenToggle.onValueChanged.RemoveListener(OnFullscreenToggle);
			_musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
			_soundsVolumeSlider.onValueChanged.RemoveListener(OnSoundsVolumeChanged);
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

		private void InitializeAudio()
		{
			var soundVolume = _storageService.SoundsVolume;
			_soundsVolumeSlider.value = soundVolume;
			OnSoundsVolumeChanged(soundVolume);

			var musicVolume = _storageService.MusicVolume;
			_musicVolumeSlider.value = musicVolume;
			OnMusicVolumeChanged(musicVolume);
		}

		private void OnSoundsVolumeChanged(float value)
		{
			_storageService.SoundsVolume = value;
			_audioMixerGroup.audioMixer.SetFloat(Constants.Audio.ExposedParameter.SoundsVolume, value.AsAudioVolume());
		}

		private void OnMusicVolumeChanged(float value)
		{
			_storageService.MusicVolume = value;
			_audioMixerGroup.audioMixer.SetFloat(Constants.Audio.ExposedParameter.MusicVolume, value.AsAudioVolume());
		}
	}
}