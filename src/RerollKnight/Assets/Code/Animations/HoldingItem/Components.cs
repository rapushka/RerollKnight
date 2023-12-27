using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	/// <summary> Prefab </summary>
	[GameScope] public sealed class HoldingItem : ValueComponent<GameObject>, IEvent<Self> { }
}