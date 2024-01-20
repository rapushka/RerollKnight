using Entitas.Generic;
using UnityEngine;

namespace Code.Editor.Tests
{
	public static class Destroy
	{
		public static class All
		{
			private static GameObject[] GameObjectsOnScene => Object.FindObjectsOfType<GameObject>();

			public static void GameObjects()
			{
				foreach (var gameObject in GameObjectsOnScene)
					Object.DestroyImmediate(gameObject);
			}

			public static void Entities<TScope>()
				where TScope : IScope
			{
				var contexts = Contexts.Instance;
				var context = contexts.Get<TScope>();
				context.DestroyAllEntities();
			}
		}
	}
}