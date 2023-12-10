using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class ThrowDicesSystem : IExecuteSystem
	{
		// private readonly IGroup<Entity<GameScope>> _entities;
		// private readonly IViewConfig _viewConfig;

		[Inject]
		public ThrowDicesSystem(Contexts contexts, IViewConfig viewConfig)
		{
			// _viewConfig = viewConfig;
			// _entities = contexts.GetGroup(Get<Actor>());
		}

		public void Execute()
		{
			// foreach (var e in _entities)
			// {
			// 	_viewConfig.RerollDuration
			// 	_viewConfig.RerollThrowHeight
			// }
		}
	}
}