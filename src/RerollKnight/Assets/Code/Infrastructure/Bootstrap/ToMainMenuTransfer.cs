using Zenject;

namespace Code
{
	public class ToMainMenuTransfer : IInitializable
	{
		private readonly ISceneTransfer _sceneTransfer;

		[Inject]
		public ToMainMenuTransfer(ISceneTransfer sceneTransfer)
		{
			_sceneTransfer = sceneTransfer;
		}

		public void Initialize() => _sceneTransfer.ToMainMenu();
	}
}