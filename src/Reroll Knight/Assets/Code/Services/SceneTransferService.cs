using UnityEngine.SceneManagement;

namespace Code.Services
{
	public interface ISceneTransferService : IService
	{
		void ToBootstrapScene();
		void ToGameplayScene();
	}

	public class SceneTransferService : ISceneTransferService
	{
		public void ToBootstrapScene() => SceneManager.LoadScene("BootstrapScene");
		public void ToGameplayScene() => SceneManager.LoadScene("GameplayScene");
	}
}