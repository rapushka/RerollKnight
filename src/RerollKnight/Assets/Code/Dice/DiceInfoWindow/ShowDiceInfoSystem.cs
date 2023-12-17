using System.Collections.Generic;
using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class ShowDiceInfoSystem : ReactiveSystem<Entity<GameScope>>
	{
		private readonly GameplayStateMachine _stateMachine;
		private readonly WindowsService _windows;

		public ShowDiceInfoSystem(Contexts contexts, GameplayStateMachine stateMachine, WindowsService windows)
			: base(contexts.Get<GameScope>())
		{
			_stateMachine = stateMachine;
			_windows = windows;
		}

		protected override ICollector<Entity<GameScope>> GetTrigger(IContext<Entity<GameScope>> context)
			=> context.CreateCollector(AllOf(Get<Actor>(), Get<Clicked>()));

		protected override bool Filter(Entity<GameScope> entity) => entity.Is<Clicked>();

		protected override void Execute(List<Entity<GameScope>> entities)
		{
			if (_stateMachine.CurrentState is not ObservingGameplayState)
				return;

			foreach (var dice in entities)
			{
				Debug.Log($"dice = {dice}");
				_windows.Show<DiceInfoWindow>().SetData(dice);
			}
		}
	}
}