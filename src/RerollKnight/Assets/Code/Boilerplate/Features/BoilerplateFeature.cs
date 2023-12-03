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
			Add(new EventSystem<GameScope, EnableOutline>(contexts));
			Add(new EventSystem<GameScope, Position>(contexts));
			Add(new EventSystem<GameScope, Component.TargetState>(contexts));
			Add(new EventSystem<GameScope, Label>(contexts));
			Add(new EventSystem<GameScope, Destroyed>(contexts));
			Add(new EventSystem<ChipsScope, Destroyed>(contexts));

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