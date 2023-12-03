using Code.Component;
using Entitas.Generic;
using JetBrains.Annotations;
using Zenject;

namespace Code
{
	public class UiMediator
	{
		private Contexts _contexts;

		[Inject]
		public void Construct(Contexts contexts)
		{
			_contexts = contexts;
		}

		[CanBeNull]
		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		public void EndTurn() => _contexts.Get<RequestScope>().CreateEntity().Add<EndTurn>();

		public bool IsEndTurnButtonAvailable => CurrentActor?.Is<Player>() ?? false;
	}
}