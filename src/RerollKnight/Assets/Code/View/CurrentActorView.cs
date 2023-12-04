using Code.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace Code
{
	public class CurrentActorView : BaseListener<GameScope, CurrentActor>
	{
		[SerializeField] private TMP_Text _textMesh;

		public override void OnValueChanged(Entity<GameScope> entity, CurrentActor component)
		{
			_textMesh.text = entity.Is<Player>() ? "Player's turn"
				: entity.Is<Enemy>()             ? "Enemy's turn"
				                                   : "Unknown";
		}
	}
}