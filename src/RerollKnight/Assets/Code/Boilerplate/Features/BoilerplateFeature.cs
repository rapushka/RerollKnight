using Code.Component;
using Entitas.Generic;

namespace Code
{
	/// <summary> Contains all boilerplate systems </summary>
	public sealed class BoilerplateFeature : Feature
	{
		public BoilerplateFeature(Contexts contexts)
			: base(nameof(BoilerplateFeature))
		{
			Add(new SelfEventSystem<GameScope, EnableOutline>(contexts));
			Add(new SelfEventSystem<GameScope, Position>(contexts));
			Add(new SelfEventSystem<GameScope, Component.TargetState>(contexts));
			Add(new SelfEventSystem<GameScope, Label>(contexts));
			Add(new SelfEventSystem<GameScope, Destroyed>(contexts));
			Add(new SelfEventSystem<ChipsScope, Destroyed>(contexts));
			Add(new SelfEventSystem<GameScope, MaxHealth>(contexts));
			Add(new SelfEventSystem<GameScope, Health>(contexts));
			Add(new AnyEventSystem<GameScope, CurrentActor>(contexts));

			Add(new RemoveComponentsSystem<Clicked, GameScope>(contexts));

			Add(new DestroyEntitySystem<CastAbility, RequestScope>(contexts));
			Add(new DestroyEntitySystem<SpawnActor, RequestScope>(contexts));
			Add(new DestroyEntitySystem<SetAllTargetsAvailability, RequestScope>(contexts));
			Add(new DestroyEntitySystem<EndTurn, RequestScope>(contexts));
			Add(new DestroyEntitySystem<Destroyed, GameScope>(contexts));
			Add(new DestroyEntitySystem<Destroyed, ChipsScope>(contexts));
		}
	}
}