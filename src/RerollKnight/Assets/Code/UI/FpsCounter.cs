using UnityEngine;

namespace Code
{
	public class FpsCounter : MonoBehaviour
	{
		private float _deltaTime;

		public void Update()
		{
			_deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
		}

		private void OnGUI()
		{
			var fps = Mathf.RoundToInt(1.0f / _deltaTime);
			var temp = GUI.color;
			GUI.color = Color.red;
			GUI.Label(new Rect(x: 10, y: 5, width: 100, height: 20), $"FPS: {fps}");
			GUI.color = temp;
		}
	}
}