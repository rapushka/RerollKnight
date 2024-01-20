using UnityEngine;

namespace Code.Editor.Tests
{
	public static class Destroy
	{
		private static GameObject[] AllGameObjects => Object.FindObjectsOfType<GameObject>();

		public static void AllGameObjectsOnScene()
		{
			foreach (var gameObject in AllGameObjects)
				Object.DestroyImmediate(gameObject);
		}
	}
}