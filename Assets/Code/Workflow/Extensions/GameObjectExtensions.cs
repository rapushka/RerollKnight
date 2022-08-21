using Code.Unity.Views;
using Code.Unity.Views.ViewController;
using Entitas;
using UnityEngine;

namespace Code.Workflow.Extensions
{
	public static class GameObjectExtensions
	{
		public static GameObject CreateController<T>(this GameObject view, IEntity entity)
			where T : Component, IViewController
		{
			view.AddComponent<T>()
			    .Initialize((GameEntity)entity);

			return view;
		}

		public static GameObject RegisterListeners(this GameObject view, IEntity entity)
		{
			IEventListener[] listeners = view.GetComponents<IEventListener>();
			listeners.ForEach((l) => l.Register(entity));

			return view;
		}
	}
}
