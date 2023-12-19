using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public class BattleLogAbilitiesSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly BattleLog _battleLog;
		private readonly IGroup<Entity<ChipsScope>> _abilities;
		private readonly IGroup<Entity<GameScope>> _targets;

		[Inject]
		public BattleLogAbilitiesSystem(Contexts contexts, BattleLog battleLog)
		{
			_contexts = contexts;
			_battleLog = battleLog;

			_abilities = contexts.GetGroup(Get<Component.AbilityState>());
			_targets = contexts.GetGroup(ScopeMatcher<GameScope>.Get<PickedTarget>());
		}

		private Entity<GameScope> PickedChip => _contexts.Get<GameScope>().Unique.GetEntity<PickedChip>();

		public void Initialize()
		{
			var chipLabel = PickedChip.Get<Label>().Value;
			_battleLog.Log($"The {chipLabel} has been Casted to {BuildTargetsString()}");
		}

		private string BuildTargetsString()
			=> string.Join(", ", _targets.GetEntities().Select(GetTargetName));

		private string GetTargetName(Entity<GameScope> entity)
		{
			var coordinates = entity.GetCoordinates();
			var coordinatesString = $"({coordinates.Column}, {coordinates.Row})";
			return $"{entity.Get<DebugName>().Value} at {coordinatesString}";
		}
	}
}