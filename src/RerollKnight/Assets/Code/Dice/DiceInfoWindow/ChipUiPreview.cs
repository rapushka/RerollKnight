using Code.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Label = Code.Component.Label;

namespace Code
{
	public class ChipUiPreview : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		[SerializeField] private TMP_Text _labelMesh;

		private Entity<GameScope> _chipEntity;

		public bool Hovered { set => _chipEntity.Is<Hovered>(value); }

		public void SetData(Entity<GameScope> chipEntity)
		{
			_chipEntity = chipEntity;
			_labelMesh.text = chipEntity.Get<Label>().Value;
		}

		public void OnPointerEnter(PointerEventData eventData) => Hovered = true;

		public void OnPointerExit(PointerEventData eventData) => Hovered = false;
	}
}