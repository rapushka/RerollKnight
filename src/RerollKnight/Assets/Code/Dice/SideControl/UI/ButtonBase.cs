using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public abstract class ButtonBase : MonoBehaviour
	{
		[SerializeField] private TMP_Text _textMesh;
		[SerializeField] private Button _button;
		[SerializeField] private GameObject _selected;

		public event Action Clicked;

		public string Text { get => _textMesh.text; set => _textMesh.text = value; }

		public bool IsSelected { set => _selected.SetActive(value); }

		protected virtual void OnEnable()  => _button.onClick.AddListener(InvokeClicked);
		protected virtual void OnDisable() => _button.onClick.RemoveListener(InvokeClicked);

		private void Start()
		{
			IsSelected = false;
		}

		private void InvokeClicked() => Clicked?.Invoke();
	}
}