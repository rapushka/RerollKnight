using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public class HUD : MonoBehaviour
	{
		[SerializeField] private Button _endTurnButton;

		private UiMediator _uiMediator;

		[Inject]
		public void Construct(UiMediator uiMediator)
			=> _uiMediator = uiMediator;

		private void OnEnable()
			=> _endTurnButton.onClick.AddListener(OnEndTurnButtonClick);

		private void OnDisable()
			=> _endTurnButton.onClick.RemoveListener(OnEndTurnButtonClick);

		private void OnEndTurnButtonClick()
		{
			_uiMediator.EndTurn();
		}
	}
}