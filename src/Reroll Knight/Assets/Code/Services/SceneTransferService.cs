using UnityEngine.SceneManagement;

namespace Code.Services
{
	public interface ISceneTransferService : IService
	{
		void ToBootstrapScene();
	}

	public class SceneTransferService : ISceneTransferService
	{
		public void ToBootstrapScene() => SceneManager.LoadScene("BootstrapScene");
	}
}