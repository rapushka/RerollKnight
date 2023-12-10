using Entitas;
using Entitas.Generic;

namespace Code
{
	public class ToCurrentActorStateIfNotRerollSystem : ToCurrentActorStateSystem, IInitializeSystem
	{
		public ToCurrentActorStateIfNotRerollSystem(Contexts contexts, IViewConfig viewConfig)
			: base(contexts, viewConfig) { }

		public void Initialize()
		{
			if (StateMachine.CurrentState is not RerollDicesGameplayState)
				ChangeState();
		}
	}
}