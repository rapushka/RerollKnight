using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code
{
	public class ToBootstrap : MonoBehaviour
	{
		private void Awake() => SceneManager.LoadScene("BootstrapScene");
	}
}