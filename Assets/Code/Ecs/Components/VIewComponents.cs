using Code.Unity.Views.ViewController;
using Code.WorkFlow.ComponentsTemplates;
using UnityEngine;

namespace Code.Ecs.Components
{
	[Game] public sealed class ViewControllerComponent : ValueComponent<IViewController> { }

	[Game] public sealed class ViewToLoadComponent : ValueComponent<string> { }

	[Game] public sealed class RigidbodyComponent : ValueComponent<Rigidbody> { }

	[Game] public sealed class CharacterControllerComponent : ValueComponent<CharacterController> { }

	[Game] public sealed class TargetRotationComponent : ValueComponent<Quaternion> { }

	[Game] public sealed class TransformComponent : ValueComponent<Transform> { }

	[Game] public sealed class GameObjectComponent : ValueComponent<GameObject> { }

	[Game] public sealed class LegsPointTransformComponent : ValueComponent<Transform> { }
}