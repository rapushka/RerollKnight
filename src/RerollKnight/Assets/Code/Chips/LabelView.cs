using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace Code.Component
{
	public class LabelView : BaseListener<GameScope, Label>
	{
		[SerializeField] private TMP_Text _textMesh;

		public override void OnValueChanged(Entity<GameScope> entity, Label component)
			=> _textMesh.text = component.Value;
	}
}