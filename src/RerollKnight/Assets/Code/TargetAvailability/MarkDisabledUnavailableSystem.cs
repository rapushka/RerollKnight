using Code.Component;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class MarkDisabledUnavailableSystem : IInitializeSystem
	{
		private readonly IGroup<Entity<GameScope>> _disabledTargets;

		public MarkDisabledUnavailableSystem(Contexts contexts)
		{
			_disabledTargets = contexts.GetGroup(AllOf(Get<Disabled>(), Get<AvailableToPick>()));
		}

		public void Initialize()
		{
			foreach (var target in _disabledTargets.GetEntities())
				target.Is<AvailableToPick>(false);
		}
	}
}