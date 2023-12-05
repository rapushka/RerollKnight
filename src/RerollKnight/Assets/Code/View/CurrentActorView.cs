using Code.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace Code
{
	public class CurrentActorView : BaseListener<GameScope, CurrentActor>
	{
		[SerializeField] private TMP_Text _textMesh;

		private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

		private static Entity<GameScope> CurrentActor => Context.Unique.GetEntityOrDefault<CurrentActor>();

		public override void Register(Entity<GameScope> entity)
		{
			base.Register(entity);

			UpdateValue(CurrentActor);
		}

		public override void OnValueChanged(Entity<GameScope> entity, CurrentActor component) => UpdateValue(entity);

		private void UpdateValue(Entity<GameScope> entity)
			=> _textMesh.text = entity is null ? "No current actor!"
				: entity.Is<Player>()          ? "Player's turn"
				: entity.Is<Enemy>()           ? "Enemy's turn"
				                                 : "Unknown";
	}
}