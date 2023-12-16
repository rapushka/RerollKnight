using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public abstract class WindowBase : MonoBehaviour, IWindow, IInitializable
	{
		[SerializeField] private GameObject _root;
		[SerializeField] private Button _closeButton;

		private bool IsOpen { get => _root.activeSelf; set => _root.SetActive(value); }

		protected virtual void OnEnable()
		{
			// ReSharper disable once Unity.NoNullPropagation – if button is destroyed it have to throw an error
			_closeButton?.onClick.AddListener(Close);
		}

		protected virtual void OnDisable()
		{
			// ReSharper disable once Unity.NoNullPropagation – if button is destroyed it have to throw an error
			_closeButton?.onClick.RemoveListener(Close);
		}

		public abstract void Initialize();

		public void Open()
		{
			if (!IsOpen)
			{
				IsOpen = true;
				OnOpen();
			}
		}

		public void Close()
		{
			if (IsOpen)
			{
				IsOpen = false;
				OnClose();
			}
		}

		protected virtual void OnOpen() { }

		protected virtual void OnClose() { }
	}
}