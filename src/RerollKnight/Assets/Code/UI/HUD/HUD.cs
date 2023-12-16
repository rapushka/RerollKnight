using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public class HUD : MonoBehaviour
	{
		[SerializeField] private Button _endTurnButton;
		[SerializeField] private Button _pauseButton;

		private UiMediator _uiMediator;

		[Inject]
		public void Construct(UiMediator uiMediator)
			=> _uiMediator = uiMediator;

		private void OnEnable()
		{
			_endTurnButton.onClick.AddListener(OnEndTurnButtonClick);
			_pauseButton.onClick.AddListener(OnPauseButtonClick);
		}

		private void OnDisable()
		{
			_endTurnButton.onClick.RemoveListener(OnEndTurnButtonClick);
			_pauseButton.onClick.RemoveListener(OnPauseButtonClick);
		}

		private void OnEndTurnButtonClick()
			=> _uiMediator.EndTurn();

		private void OnPauseButtonClick()
			=> _uiMediator.Pause();

		private void Update()
			=> _endTurnButton.enabled = _uiMediator.IsEndTurnButtonAvailable;
	}
}