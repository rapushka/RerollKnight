using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using JetBrains.Annotations;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class ViewCurrentActorSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _entities;
		private readonly Contexts _contexts;

		public ViewCurrentActorSystem(Contexts contexts)
		{
			_contexts = contexts;
			_entities = contexts.GetGroup(Get<ViewOf>());
		}

		[CanBeNull]
		private Entity<GameScope> CurrentActor => _contexts.Get<GameScope>().Unique.GetEntityOrDefault<CurrentActor>();

		public void Execute()
		{
			var value = CurrentActor is null ? "No Current Actor!"
				: CurrentActor.Is<Player>()  ? "Player's turn"
				: CurrentActor.Is<Enemy>()   ? "Enemy's Turn"
				                               : "Unknown Actor!";

			foreach (var e in _entities.Where(IsViewOfCurrentActor))
				e.Replace<Label, string>(value);
		}

		private bool IsViewOfCurrentActor(Entity<GameScope> entity)
			=> entity.Get<ViewOf>().Value.All(ForCurrentActor);

		private bool ForCurrentActor(GameComponentID componentID)
			=> componentID.Is<CurrentActor>();
	}
}