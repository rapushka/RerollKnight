using Code.Component;
using Entitas.Generic;
using TMPro;
using UnityEngine;
using Zenject;
using static Code.Constants;

namespace Code
{
	public class CurrentActorView : BaseListener<GameScope, CurrentActor>
	{
		[SerializeField] private TMP_Text _textMesh;

		private ILocalizationService _localizationService;

		[Inject]
		public void Construct(ILocalizationService localizationService)
			=> _localizationService = localizationService;

		private static ScopeContext<GameScope> Context => Contexts.Instance.Get<GameScope>();

		private static Entity<GameScope> CurrentActor => Context.Unique.GetEntityOrDefault<CurrentActor>();

		public override void Register(Entity<GameScope> entity)
		{
			base.Register(entity);

			UpdateValue(CurrentActor);
		}

		public override void OnValueChanged(Entity<GameScope> entity, CurrentActor component) => UpdateValue(entity);

		private void UpdateValue(Entity<GameScope> entity)
		{
			var key = entity is null  ? Localization.Key.NoCurrentActor
				: entity.Is<Player>() ? Localization.Key.PlayerCurrentActor
				: entity.Is<Enemy>()  ? Localization.Key.EnemyCurrentActor
				                        : Localization.Key.NoCurrentActor;

			_textMesh.text = _localizationService.GetLocalized(Localization.Table.Game, key);
		}
	}
}