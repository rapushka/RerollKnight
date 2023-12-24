using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class PickSideWindow : WindowBase
	{
		[SerializeField] private SideButton _sideButtonPrefab;
		[SerializeField] private Transform _sidesRoot;

		protected Entity<GameScope> Actor;

		protected readonly List<SideButton> SideButtons = new();

		public virtual void SetData(Entity<GameScope> actor)
		{
			Actor = actor;

			foreach (var face in actor.GetDependants().WhereHas<Face>())
			{
				var sideButton = Instantiate(_sideButtonPrefab, _sidesRoot);
				sideButton.SetData(face.Get<Face>().Value);
				sideButton.Clicked += OnSidePicked;
				SideButtons.Add(sideButton);
			}
		}

		protected override void OnHide()
		{
			foreach (var sideButton in SideButtons)
			{
				sideButton.Clicked -= OnSidePicked;
				Destroy(sideButton.gameObject);
			}

			SideButtons.Clear();
		}

		protected virtual void OnSidePicked(int sideNumber)
		{
			Actor.Replace<PredefinedNextSide, int>(sideNumber);
			Hide();
		}
	}
}