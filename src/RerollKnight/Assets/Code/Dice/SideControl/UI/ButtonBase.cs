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

		public event Action Clicked;

		public string Text { get => _textMesh.text; set => _textMesh.text = value; }

		protected virtual void OnEnable()  => _button.onClick.AddListener(InvokeClicked);
		protected virtual void OnDisable() => _button.onClick.RemoveListener(InvokeClicked);

		private void InvokeClicked() => Clicked?.Invoke();
	}
}