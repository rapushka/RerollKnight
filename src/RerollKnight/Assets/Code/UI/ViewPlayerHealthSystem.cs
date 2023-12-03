using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class ViewPlayerHealthSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _views;
		private readonly IGroup<Entity<GameScope>> _players;

		[Inject]
		public ViewPlayerHealthSystem(Contexts contexts)
		{
			_views = contexts.GetGroup(Get<ViewOf>());
			_players = contexts.GetGroup(Get<Player>());
		}

		public void Execute()
		{
			foreach (var player in _players)
			foreach (var view in _views.Where(IsPlayerHealthView))
			{
				if (view.Get<ViewOf>().Value.All((cc) => cc.Match(player)))
					view.Replace<Label, string>(player.Get<Health>().Value.ToString());
			}
		}

		private bool IsPlayerHealthView(Entity<GameScope> entity)
			=> entity.Get<ViewOf>().Value.All((cc) => cc.Is<Player>() || cc.Is<Health>());
	}
}