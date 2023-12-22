using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class PickSideWindow : WindowBase
	{
		[SerializeField] private SideButton _sideButtonPrefab;
		[SerializeField] private Transform _sidesRoot;

		private static Entity<GameScope> CurrentActor => Context.Unique.GetEntity<CurrentActor>();

		private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

		protected override void OnShow()
		{
			for (var i = 0; i < Constants.PlayerSidesCount; i++)
			{
				var sideButton = Instantiate(_sideButtonPrefab, _sidesRoot);
				sideButton.SetData(i + 1);
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
			Context.CreateEntity()
			       .Identify()
			       .Add<ForeignID, string>(CurrentActor.EnsureID())
			       .Add<PredefinedNextSide, int>(sideNumber);

			Hide();
		}
	}
}