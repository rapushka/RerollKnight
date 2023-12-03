using System.Linq;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class ViewEnemyHealthSystem : IExecuteSystem
	{
		private readonly IGroup<Entity<GameScope>> _views;
		private readonly IGroup<Entity<GameScope>> _enemy;

		[Inject]
		public ViewEnemyHealthSystem(Contexts contexts)
		{
			_views = contexts.GetGroup(ScopeMatcher<GameScope>.Get<ViewOf>());
			_enemy = contexts.GetGroup(ScopeMatcher<GameScope>.Get<Enemy>());
		}

		public void Execute()
		{
			foreach (var enemy in _enemy)
			foreach (var view in _views.Where(IsEnemyHealthView))
			{
				if (view.Get<ViewOf>().Value.All((cc) => cc.Match(enemy)))
					view.Replace<Label, string>(enemy.Get<Health>().Value.ToString());
			}
		}

		private bool IsEnemyHealthView(Entity<GameScope> entity)
			=> entity.Get<ViewOf>().Value.All((cc) => cc.Is<Enemy>() || cc.Is<Health>());
	}
}