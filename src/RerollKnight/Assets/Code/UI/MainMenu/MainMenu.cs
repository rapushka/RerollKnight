using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public class MainMenu : MonoBehaviour
	{
		[SerializeField] private Button _playButton;
		[SerializeField] private Button _settingsButton;
		[SerializeField] private Button _exitButton;

		private UiMediator _uiMediator;

		[Inject]
		public void Construct(UiMediator uiMediator)
		{
			_uiMediator = uiMediator;
		}

		private void OnEnable()
		{
			_playButton.onClick.AddListener(_uiMediator.OpenGameplayScene);
			_settingsButton.onClick.AddListener(_uiMediator.OpenWindow<SettingsWindow>);
			_exitButton.onClick.AddListener(_uiMediator.Exit);
		}

		private void OnDisable()
		{
			_playButton.onClick.RemoveListener(_uiMediator.OpenGameplayScene);
			_settingsButton.onClick.RemoveListener(_uiMediator.OpenWindow<SettingsWindow>);
			_exitButton.onClick.RemoveListener(_uiMediator.Exit);
		}
	}
}