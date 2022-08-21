using Code.Unity.Views;
using Entitas;
using UnityEngine;

namespace Code.Workflow.Extensions
{
	public static class GameObjectExtensions
	{
		public static GameObject RegisterListeners(this GameObject view, IEntity entity)
		{
			IEventListener[] listeners = view.GetComponents<IEventListener>();
			listeners.ForEach((l) => l.Register(entity));

			return view;
		}
	}
}
