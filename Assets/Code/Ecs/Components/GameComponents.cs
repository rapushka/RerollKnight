using Code.Unity.Services.Interfaces;
using Code.WorkFlow.ComponentsTemplates;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code.Ecs.Components
{
	[Game] [Unique] public sealed class TimeService : ValueComponent<ITimeService> { }
	[Game] [Unique] public sealed class BalanceService : ValueComponent<IBalanceService> { }
	[Game] [Unique] public sealed class ResourcesService : ValueComponent<IResourcesService> { }

	[Game] [Unique] public sealed class GravityScaleComponent : ValueComponent<float> { }

	[Game] public sealed class WeightyComponent : FlagComponent { }

	[Game] [Event(Self)] public sealed class RigidbodyComponent : ValueComponent<Rigidbody> { }

	[Game] [Event(Self)] public sealed class PositionComponent : ValueComponent<Vector2> { }
}
