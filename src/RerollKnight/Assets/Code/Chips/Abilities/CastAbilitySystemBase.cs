using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.ChipsScope>;

namespace Code
{
	public abstract class CastAbilitySystemBase<TAbility> : IInitializeSystem
		where TAbility : IComponent, new()
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<GameScope>> _targets;
		private readonly IGroup<Entity<ChipsScope>> _abilities;

		[Inject]
		protected CastAbilitySystemBase(Contexts contexts)
		{
			_contexts = contexts;
			_targets = contexts.GetGroup(ScopeMatcher<GameScope>.Get<PickedTarget>());
			_abilities = contexts.GetGroup(AllOf(Get<TAbility>(), Get<Component.AbilityState>()));
		}

		protected Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntity<CurrentActor>();

		public void Initialize()
		{
			foreach (var ability in _abilities.WhereStateIs(AbilityState.Casting))
			foreach (var target in _targets)
			{
				Cast(ability, target);
				ability.Replace<Component.AbilityState, AbilityState>(AbilityState.Casted);
			}
		}

		protected abstract void Cast(Entity<ChipsScope> ability, Entity<GameScope> target);
	}
}