using cakeslice;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class OutlineView
		: BaseListener<GameScope>,
		  IRegistrableListener<GameScope, EnableOutline>,
		  IRegistrableListener<GameScope, TargetStateComponent>
	{
		[SerializeField] private Outline _outline;

		public override void Register(Entity<GameScope> entity)
		{
			entity.AddListener<EnableOutline>(this);
			entity.AddListener<TargetStateComponent>(this);

			if (entity.Has<EnableOutline>() && entity.Has<TargetStateComponent>())
				UpdateValue(entity);
		}

		public void OnValueChanged(Entity<GameScope> entity, EnableOutline component) => UpdateValue(entity);

		public void OnValueChanged(Entity<GameScope> entity, TargetStateComponent component) => UpdateValue(entity);

		private void UpdateValue(Entity<GameScope> entity)
		{
			_outline.enabled = entity.Is<EnableOutline>();
			_outline.color = (int)entity.Get<TargetStateComponent>().Value;
		}
	}
}