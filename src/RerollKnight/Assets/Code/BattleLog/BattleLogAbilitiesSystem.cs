using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public class BattleLogAbilitiesSystem : IInitializeSystem
	{
		private readonly BattleLog _battleLog;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		[Inject]
		public BattleLogAbilitiesSystem(Contexts contexts, BattleLog battleLog)
		{
			_abilities = contexts.GetGroup(Get<Component.AbilityState>());
			_battleLog = battleLog;
		}

		public void Initialize()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Casting))
			{
				var chip = ability.GetOwner<ChipsScope, GameScope>();
				_battleLog.Log($"{chip.Get<Label>().Value} Was Casted");
			}
		}
	}
}