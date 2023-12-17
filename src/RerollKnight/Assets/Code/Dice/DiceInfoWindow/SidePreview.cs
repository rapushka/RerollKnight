using System.Linq;
using Code.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace Code
{
	public class SidePreview : MonoBehaviour
	{
		[SerializeField] private Transform _chipsRoot;
		[SerializeField] private GameObject _isActiveLabel;
		[SerializeField] private TMP_Text _sideNumberTextMesh;
		[SerializeField] private ChipUiPreview _chipPreviewPrefab;

		public void SetData(Entity<GameScope> sideEntity)
		{
			_sideNumberTextMesh.text = sideEntity.Get<Face>().Value.ToString();
			_isActiveLabel.SetActive(sideEntity.IsActiveFace());

			foreach (var chip in sideEntity.GetDependants().Where((e) => e.Is<Chip>()))
			{
				var chipPreview = Instantiate(_chipPreviewPrefab, _chipsRoot);
				chipPreview.SetData(chip);
			}
		}
	}
}