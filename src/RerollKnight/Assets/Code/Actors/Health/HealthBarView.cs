using Code.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace Code
{
	public class HealthBarView
		: BaseListener<GameScope>,
		  IRegistrableListener<GameScope, Health>,
		  IRegistrableListener<GameScope, MaxHealth>
	{
		[SerializeField] private TMP_Text _textMesh;

		public override void Register(Entity<GameScope> entity)
		{
			entity.AddListener<Health>(this);
			entity.AddListener<MaxHealth>(this);

			if (entity.Has<Health>() && entity.Has<MaxHealth>())
				UpdateValue(entity);
		}

		public void OnValueChanged(Entity<GameScope> entity, Health component) => UpdateValue(entity);

		public void OnValueChanged(Entity<GameScope> entity, MaxHealth component) => UpdateValue(entity);

		private void UpdateValue(Entity<GameScope> entity)
			=> _textMesh.text = $"{entity.Get<Health>().Value}/{entity.Get<MaxHealth>().Value}";
	}
}