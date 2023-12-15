using Zenject;

namespace Code
{
	public class Starter : IInitializable
	{
		private readonly ISceneTransfer _sceneTransfer;

		[Inject]
		public Starter(ISceneTransfer sceneTransfer)
		{
			_sceneTransfer = sceneTransfer;
		}

		public void Initialize() => _sceneTransfer.ToBootstrap();
	}
}