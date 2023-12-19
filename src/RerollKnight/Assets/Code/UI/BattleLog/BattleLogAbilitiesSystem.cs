using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Code.LocalizationKey;
using static Code.LocalizationTable;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class BattleLogAbilitiesSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly BattleLog _battleLog;
		private readonly ILocalizationService _localization;

		private readonly IGroup<Entity<GameScope>> _targets;

		[Inject]
		public BattleLogAbilitiesSystem
		(
			Contexts contexts,
			BattleLog battleLog,
			ILocalizationService localization
		)
		{
			_contexts = contexts;
			_battleLog = battleLog;
			_localization = localization;

			_targets = contexts.GetGroup(Get<PickedTarget>());
		}

		private Entity<GameScope> PickedChip => _contexts.Get<GameScope>().Unique.GetEntity<PickedChip>();

		public void Initialize()
		{
			var chipLabel = PickedChip.Get<Label>().Value;
			var target = BuildTargetsString();
			var localizedString = Localize(ChipCastedMessage, chipLabel, target);

			_battleLog.Log(localizedString);
		}

		private string BuildTargetsString()
			=> string.Join(", ", _targets.GetEntities().Select(GetTargetName));

		private string GetTargetName(Entity<GameScope> entity)
		{
			var targetDisplayName = entity.GetDisplayName();
			var coordinates = entity.GetCoordinates().ToShortString();

			return Localize(EntityAtCoordinatesMessage, targetDisplayName, coordinates);
		}

		private string Localize(string key, params object[] args)
			=> _localization.GetLocalized(table: DisplayNames, key, args);
	}
}