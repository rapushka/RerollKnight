using System.Linq;
using Code.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public class SidePreview : MonoBehaviour
	{
		[SerializeField] private Transform _chipsRoot;
		[SerializeField] private GameObject _isActiveLabel;
		[SerializeField] private GameObject _isNextLabel;
		[SerializeField] private TMP_Text _sideNumberTextMesh;
		[SerializeField] private ChipUiPreview _chipPreviewPrefab;
		[SerializeField] private HorizontalLayoutGroup _chipsLayoutGroup;

		[Header("View")]
		[SerializeField] private int _chipsOverflowThreshold = 6;
		[SerializeField] private float _overflowShorter = 30f;

		public void SetData(Entity<GameScope> sideEntity)
		{
			_sideNumberTextMesh.text = sideEntity.Get<Face>().Value.ToString();
			_isActiveLabel.SetActive(sideEntity.IsActiveFace());
			_isNextLabel.SetActive(sideEntity.IsNextFace());
			var chipsCount = 0;

			foreach (var chip in sideEntity.GetDependants().Where((e) => e.Is<Chip>()))
			{
				var chipPreview = Instantiate(_chipPreviewPrefab, _chipsRoot);
				chipPreview.SetData(chip);
				chipsCount++;
			}

			var chipsOverflow = chipsCount - _chipsOverflowThreshold;
			if (chipsOverflow > 0)
				_chipsLayoutGroup.spacing = chipsOverflow * -_overflowShorter;
		}
	}
}