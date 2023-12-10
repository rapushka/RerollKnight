using System.Diagnostics.CodeAnalysis;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class PassTurnToNextActorSystem : IInitializeSystem, IStateTransferSystem
	{
		private readonly TurnsQueue _turnsQueue;
		private readonly Contexts _contexts;

		[Inject]
		public PassTurnToNextActorSystem(Contexts contexts, TurnsQueue turnsQueue)
		{
			_contexts = contexts;
			_turnsQueue = turnsQueue;
		}

		public StateMachineBase StateMachine { get; set; }

		[AllowNull]
		private Entity<GameScope> CurrentPlayer => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		public void Initialize()
		{
			if (_turnsQueue.CurrentIsLast)
				StateMachine.ToState<RerollDicesGameplayState>();

			CurrentPlayer?.Is<CurrentActor>(false);
			var actor = _turnsQueue.Next();
			actor.Is<CurrentActor>(true);
		}
	}
}