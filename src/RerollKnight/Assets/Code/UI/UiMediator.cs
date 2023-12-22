using Zenject;

namespace Code
{
	public class UiMediator
	{
		private ISceneTransfer _sceneTransfer;
		private WindowsService _windows;
		private Game _game;

		[Inject]
		public void Construct(ISceneTransfer sceneTransfer, WindowsService windows, Game game)
		{
			_sceneTransfer = sceneTransfer;
			_windows = windows;
			_game = game;
		}

		public void EndTurn() => _game.EndTurn();

		public bool IsEndTurnButtonAvailable => _game.IsPlayerCurrentActor;

		public void OpenGameplayScene() => _sceneTransfer.ToGameplay();

		public void Pause() => _sceneTransfer.ToMainMenu();

		public void    ShowWindow<TWindow>() where TWindow : IWindow       => _windows.Show<TWindow>();
		public void    HideWindow<TWindow>() where TWindow : IWindow       => _windows.Hide<TWindow>();
		public void    HideCurrentWindow()                                 => _windows.HideCurrent();
		public TWindow ShowAndGetWindow<TWindow>() where TWindow : IWindow => _windows.Show<TWindow>();

		public void Exit() => _game.Exit();
	}
}