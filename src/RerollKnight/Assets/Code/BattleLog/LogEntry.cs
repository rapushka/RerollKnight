using TMPro;
using UnityEngine;

namespace Code
{
	public class LogEntry : MonoBehaviour
	{
		[SerializeField] private TMP_Text _textMesh;

		public string Message { set => _textMesh.text = value; }

		public float Opacity
		{
			get => _textMesh.color.a;
			set => _textMesh.SetColor(a: value);
		}
	}
}