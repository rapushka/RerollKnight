using Code.Ecs.Systems.Controls.Aiming;
using Code.Ecs.Systems.View;

namespace Code.Ecs.Features
{
	public sealed class ViewSystems : Feature
	{
		public ViewSystems(Contexts contexts)
			: base(nameof(ViewSystems))
		{
			Add(new AddPlayerViewToLoadSystem(contexts));
			Add(new LoadViewSystem(contexts));
			
			Add(new SetupAimingAtCursorSystem(contexts));
		}
	}
}
