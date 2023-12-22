using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public class SideButton : MonoBehaviour
	{
		[SerializeField] private TMP_Text _textMesh;
		[SerializeField] private Button _button;

		public event Action<int> Clicked;

		private int _sideNumber;

		protected void OnEnable()  => _button.onClick.AddListener(InvokeClicked);
		protected void OnDisable() => _button.onClick.RemoveListener(InvokeClicked);

		public void SetData(int sideNumber)
		{
			_sideNumber = sideNumber;
			_textMesh.text = _sideNumber.ToString();
		}

		private void InvokeClicked() => Clicked?.Invoke(_sideNumber);
	}
}