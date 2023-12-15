using UnityEngine.SceneManagement;

namespace Code
{
	public interface ISceneTransfer
	{
		void ToBootstrap();
		void ToMainMenu();
		void ToGameplay();
	}

	public class SceneTransfer : ISceneTransfer
	{
		public void ToBootstrap() => SceneManager.LoadScene("Bootstrap Scene");

		public void ToMainMenu() => SceneManager.LoadScene("Main Menu Scene");

		public void ToGameplay() => SceneManager.LoadScene("Gameplay Scene");
	}
}