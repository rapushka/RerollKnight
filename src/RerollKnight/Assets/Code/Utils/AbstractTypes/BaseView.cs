using UnityEngine;

namespace Code
{
	public abstract class BaseView : MonoBehaviour
	{
		public GameEntity Entity { get; private set; }

		public void Register(GameEntity entity)
		{
			Entity = entity;
			AddListener(entity);
			if (HasComponent(entity))
			{
				UpdateValue(entity);
			}
		}

		protected abstract void AddListener(GameEntity entity);

		protected abstract bool HasComponent(GameEntity entity);

		protected abstract void UpdateValue(GameEntity entity);
	}
}