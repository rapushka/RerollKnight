using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static Code.Constants.Localization;

namespace Code
{
	public class HUD : MonoBehaviour
	{
		[SerializeField] private Button _endTurnButton;
		[SerializeField] private Button _pauseButton;
		[SerializeField] private TMP_Text _nextSideTextMesh;

		private UiMediator _uiMediator;
		private ILocalizationService _localization;

		[Inject]
		public void Construct(UiMediator uiMediator, ILocalizationService localization)
		{
			_uiMediator = uiMediator;
			_localization = localization;
		}

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
		{
			UpdateEndTurnButton();
			UpdateNextSideView();
		}

		private void UpdateEndTurnButton()
			=> _endTurnButton.enabled = _uiMediator.IsEndTurnButtonAvailable;

		private void UpdateNextSideView()
		{
			var nextSide = _uiMediator.PlayerNextSide;
			_nextSideTextMesh.gameObject.SetActive(nextSide != -1);
			_nextSideTextMesh.text = _localization.GetLocalized(Table.Game, Key.NextSideHudView, nextSide);
		}
	}
}