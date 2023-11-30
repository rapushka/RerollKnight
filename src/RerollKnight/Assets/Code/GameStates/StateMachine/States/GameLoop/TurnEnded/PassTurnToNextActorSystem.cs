using System.Diagnostics.CodeAnalysis;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class PassTurnToNextActorSystem : IInitializeSystem
	{
		private readonly TurnsQueue _turnsQueue;
		private readonly Contexts _contexts;

		[Inject]
		public PassTurnToNextActorSystem(Contexts contexts, TurnsQueue turnsQueue)
		{
			_contexts = contexts;
			_turnsQueue = turnsQueue;
		}

		[AllowNull]
		private Entity<GameScope> CurrentPlayer => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		public void Initialize()
		{
			CurrentPlayer?.Is<CurrentActor>(false);
			var actor = _turnsQueue.Next();
			actor.Is<CurrentActor>(true);
		}
	}
}