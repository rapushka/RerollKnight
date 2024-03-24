using Code.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace Code
{
	public class ChipDescriptionWindow : WindowBase
	{
		[SerializeField] private TMP_Text _descriptionTextMesh;

		private Entity<GameScope> _hoveredChip;

		public void SetData(Entity<GameScope> chip)
		{
			_hoveredChip = chip;
			_descriptionTextMesh.text = _hoveredChip.Get<Description>().Value;
		}
	}
}