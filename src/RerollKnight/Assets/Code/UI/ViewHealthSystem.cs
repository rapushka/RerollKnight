using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class ViewHealthSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _views;

		[Inject]
		public ViewHealthSystem(Contexts contexts)
		{
			_views = contexts.GetGroup(Get<ViewOf>());
			contexts.GetGroup(Get<Player>());
		}

		public void Execute()
		{
			foreach (var view in _views.Where(IsHealthView))
			{
				var actor = ID.Index.GetEntity(view.Get<BelongToActor>().Value);
				view.Replace<Label, string>(actor.Get<Health>().Value.ToString());
			}
		}

		private bool IsHealthView(Entity<GameScope> entity)
			=> entity.Get<ViewOf>().Value.Any((cc) => cc.Is<Health>());
	}
}