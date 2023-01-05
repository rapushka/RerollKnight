using Code.Services;
using UnityEngine;

namespace Code
{
	public class ToBootstrap : MonoBehaviour
	{
		private void Awake() => new SceneTransferService().ToBootstrapScene();
	}
}