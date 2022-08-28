using Code.Ecs.Systems.Controls.Aiming;
using Code.Ecs.Systems.View;
using Code.Ecs.Systems.View.Initialization;

namespace Code.Ecs.Features.CommonSystems
{
	public sealed class ViewSystems : Feature
	{
		public ViewSystems(Contexts contexts)
			: base(nameof(ViewSystems))
		{
			Add(new BindViewsToLoadSystem(contexts));
			Add(new LoadViewSystem(contexts));

			Add(new WeaponToPlayerParentSystem(contexts));
			Add(new SetupAimingAtCursorSystem(contexts));
			Add(new MoveViewToInitialPositionSystem(contexts));
		}
	}
}
