using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class EndTurnOnCurrentActorDeathSystem : ReactiveSystem<Entity<GameScope>>
	{
		private GameplayStateMachine _stateMachine;

		public EndTurnOnCurrentActorDeathSystem(Contexts contexts, GameplayStateMachine stateMachine)
			: base(contexts.Get<GameScope>())
			=> _stateMachine = stateMachine;

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Actor>(), Get<Destroyed>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Destroyed>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			// ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator - explicit intend
			foreach (var actor in entities)
			{
				if (actor.Is<CurrentActor>())
					_stateMachine.ToState<TurnEndedGameplayState>();
			}
		}
	}
}