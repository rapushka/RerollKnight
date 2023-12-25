using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public abstract class WindowBase : MonoBehaviour, IWindow, IInitializable
	{
		[SerializeField] private GameObject _root;
		[SerializeField] private Button _closeButton;

		public bool IsOpen { get => _root.activeSelf; private set => _root.SetActive(value); }

		protected virtual void OnEnable()
		{
			// ReSharper disable once Unity.NoNullPropagation – if button is destroyed it have to throw an error
			_closeButton?.onClick.AddListener(Hide);
		}

		protected virtual void OnDisable()
		{
			// ReSharper disable once Unity.NoNullPropagation – if button is destroyed it have to throw an error
			_closeButton?.onClick.RemoveListener(Hide);
		}

		public virtual void Initialize() { }

		public void Show()
		{
			if (!IsOpen)
			{
				IsOpen = true;
				OnShow();
			}
		}

		public void Hide()
		{
			if (IsOpen)
			{
				IsOpen = false;
				OnHide();
			}
		}

		protected virtual void OnShow() { }

		protected virtual void OnHide() { }
	}
}