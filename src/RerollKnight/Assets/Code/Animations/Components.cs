using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	/// <summary> Animation that have to play now </summary>
	[GameScope] public sealed class PlayAnimation : ValueComponent<AnimationClip>, IEvent<Self> { }

	/// <summary> Animation, that will be player when the chip will be casted </summary>
	[GameScope] public sealed class CastAnimation : ValueComponent<AnimationClip> { }

	[GameScope] public sealed class AnimationPrepared : FlagComponent { }
}