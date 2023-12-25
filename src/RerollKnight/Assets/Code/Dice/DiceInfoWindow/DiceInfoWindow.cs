using System.Linq;
using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DiceInfoWindow : WindowBase, IUninterruptedWindow
	{
		[Header("Content")]
		[SerializeField] private RectTransform _sidesRoot;
		[SerializeField] private SidePreview _sidePreviewPrefab;

		public void SetData(Entity<GameScope> diceEntity)
		{
			foreach (var face in diceEntity.GetDependants().Where((e) => e.Has<Face>()))
			{
				var sidePreview = Instantiate(_sidePreviewPrefab, _sidesRoot);
				sidePreview.SetData(face);
			}
		}

		protected override void OnHide()
		{
			foreach (Transform child in _sidesRoot)
				Destroy(child.gameObject);
		}
	}
}