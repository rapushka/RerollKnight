using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public abstract class BaseView : MonoBehaviour
	{
		public Entity<GameScope> Entity { get; private set; }

		public void Register(Entity<GameScope> entity)
		{
			Entity = entity;
			AddListener(entity);
			if (HasComponent(entity))
			{
				UpdateValue(entity);
			}
		}

		protected abstract void AddListener(Entity<GameScope> entity);

		protected abstract bool HasComponent(Entity<GameScope> entity);

		protected abstract void UpdateValue(Entity<GameScope> entity);
	}
}