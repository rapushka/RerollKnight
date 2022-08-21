using Code.Unity.Views.ViewController;
using Code.WorkFlow.ComponentsTemplates;

namespace Code.Ecs.Components
{
	[Game] public sealed class ViewControllerComponent : ValueComponent<IViewController> { }
	
	[Game] public sealed class ViewToLoadComponent : ValueComponent<string> { }
}
