using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	[GameScope] public sealed class PlayAnimation : ValueComponent<AnimationClip>, IEvent<Self> { }
}