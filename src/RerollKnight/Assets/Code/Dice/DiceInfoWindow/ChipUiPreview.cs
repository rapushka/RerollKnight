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
		[SerializeField] private TMP_Text _labelTextMesh;
		[SerializeField] private GameObject _descriptionRoot;
		[SerializeField] private TMP_Text _descriptionTextMesh;

		public bool Hovered { set => _descriptionRoot.SetActive(value); }

		public void SetData(Entity<GameScope> chipEntity)
		{
			_labelTextMesh.text = chipEntity.Get<Label>().Value;
			_descriptionTextMesh.text = chipEntity.Get<Description>().Value;
			Hovered = false;
		}

		public void OnPointerEnter(PointerEventData eventData) => Hovered = true;

		public void OnPointerExit(PointerEventData eventData) => Hovered = false;
	}
}