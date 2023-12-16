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
			_playButton.onClick.AddListener(_uiMediator.OpenGameplay);
			_settingsButton.onClick.AddListener(_uiMediator.OpenSettings);
			_exitButton.onClick.AddListener(_uiMediator.Exit);
		}
	}
}