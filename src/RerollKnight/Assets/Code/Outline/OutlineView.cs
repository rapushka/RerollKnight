using cakeslice;
using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class OutlineView
		: BaseListener<GameScope>,
		  IRegistrableListener<GameScope, EnableOutline>,
		  IRegistrableListener<GameScope, Component.TargetState>
	{
		[SerializeField] private Outline _outline;

		public override void Register(Entity<GameScope> entity)
		{
			entity.AddListener<EnableOutline>(this);
			entity.AddListener<Component.TargetState>(this);

			if (entity.Has<EnableOutline>() && entity.Has<Component.TargetState>())
				UpdateValue(entity);
		}

		public void OnValueChanged(Entity<GameScope> entity, EnableOutline component) => UpdateValue(entity);

		public void OnValueChanged(Entity<GameScope> entity, Component.TargetState component) => UpdateValue(entity);

		private void UpdateValue(Entity<GameScope> entity)
		{
			_outline.enabled = entity.Is<EnableOutline>();
			_outline.color = (int)entity.Get<Component.TargetState>().Value;
		}
	}
}