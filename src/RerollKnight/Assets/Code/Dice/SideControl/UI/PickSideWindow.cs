using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class PickSideWindow : WindowBase
	{
		[SerializeField] private SideButton _sideButtonPrefab;
		[SerializeField] private Transform _sidesRoot;

		private Entity<GameScope> _actor;

		public void SetData(Entity<GameScope> actor)
		{
			_actor = actor;

			foreach (var face in actor.GetDependants().WhereHas<Face>())
			{
				var sideButton = Instantiate(_sideButtonPrefab, _sidesRoot);
				sideButton.SetData(face.Get<Face>().Value);
				sideButton.Clicked += OnSidePicked;
			}
		}

		protected override void OnHide()
		{
			foreach (Transform child in _sidesRoot)
			{
				child.GetComponent<SideButton>().Clicked -= OnSidePicked;
				Destroy(child.gameObject);
			}
		}

		private void OnSidePicked(int sideNumber)
		{
			_actor.Replace<PredefinedNextSide, int>(sideNumber);

			Hide();
		}
	}
}