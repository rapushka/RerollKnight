using Code.Unity.Services.Interfaces;
using Code.WorkFlow.ComponentsTemplates;
using Entitas.CodeGeneration.Attributes;

namespace Code.Ecs.Components
{
	[Game] [Unique] public sealed class TimeService : ValueComponent<ITimeService> { }

	[Game] [Unique] public sealed class BalanceService : ValueComponent<IBalanceService> { }

	[Game] [Unique] public sealed class ResourcesService : ValueComponent<IResourcesService> { }

	[Game] [Unique] public sealed class ViewService : ValueComponent<IViewsService> { }

}
