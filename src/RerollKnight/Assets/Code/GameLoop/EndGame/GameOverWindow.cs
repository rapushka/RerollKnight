using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public class GameOverWindow : WindowBase
	{
		[SerializeField] private Button _backToMainMenuButton;
		private ISceneTransfer _sceneTransfer;

		[Inject]
		public void Construct(ISceneTransfer sceneTransfer) => _sceneTransfer = sceneTransfer;

		protected override void OnShow()
			=> _backToMainMenuButton.onClick.AddListener(BackToMainMenu);

		protected override void OnHide()
			=> _backToMainMenuButton.onClick.RemoveListener(BackToMainMenu);

		private void BackToMainMenu() => _sceneTransfer.ToMainMenu();
	}
}