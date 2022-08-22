using Code.Ecs.Systems.ViewSystems;

namespace Code.Ecs.Features
{
	public sealed class ViewSystems : Feature
	{
		public ViewSystems(Contexts contexts)
			: base(nameof(ViewSystems))
		{
			Add(new MirrorByDirectionSystem(contexts));
			Add(new AddPlayerViewToLoadSystem(contexts));
			Add(new LoadViewSystem(contexts));
			Add(new SetupAimingAtCursorSystem(contexts));
		}
	}
}
