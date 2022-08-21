using Code.Unity.Services.Interfaces;
using Code.WorkFlow.ComponentsTemplates;
using Entitas.CodeGeneration.Attributes;

namespace Code.Ecs.Components
{
	[Services] [Unique] public sealed class TimeService : ValueComponent<ITimeService> { }

	[Services] [Unique] public sealed class BalanceService : ValueComponent<IBalanceService> { }

	[Services] [Unique] public sealed class ResourcesService : ValueComponent<IResourcesService> { }

	[Services] [Unique] public sealed class ViewService : ValueComponent<IViewsService> { }
	[Services] [Unique] public sealed class InputService : ValueComponent<IInputService> { }

}
