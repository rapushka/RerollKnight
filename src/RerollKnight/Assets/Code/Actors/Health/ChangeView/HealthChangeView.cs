using Code.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace Code
{
	public class HealthChangeView : BaseListener<GameScope, HealthChanged>
	{
		[SerializeField] private TMP_Text _textMesh;
		[SerializeField] private Color _damageColor = Color.red;
		[SerializeField] private Color _healColor = Color.green;

		public override void OnValueChanged(Entity<GameScope> entity, HealthChanged component)
			=> SetData(component.Value);

		public void SetData(int delta)
		{
			if (delta <= 0)
				ShowDamageTaken(delta);
			else
				ShowHeal(delta);
		}

		private void ShowDamageTaken(int delta)
		{
			_textMesh.text = delta.ToString();
			_textMesh.color = _damageColor;
		}

		private void ShowHeal(int delta)
		{
			_textMesh.text = $"+{delta}";
			_textMesh.color = _healColor;
		}
	}
}