using UnityEngine;
using Zenject;

namespace Code
{
	public abstract class WindowBase : MonoBehaviour, IWindow, IInitializable
	{
		[SerializeField] private GameObject _root;

		public abstract void Initialize();

		public void Open()
		{
			_root.SetActive(true);

			OnOpen();
		}

		public void Close()
		{
			_root.SetActive(false);

			OnClose();
		}

		protected virtual void OnOpen() { }

		protected virtual void OnClose() { }
	}
}