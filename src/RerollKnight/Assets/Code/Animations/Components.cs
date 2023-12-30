using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	/// <summary> Animation that have to play now </summary>
	[GameScope] public sealed class PlayAnimation : ValueComponent<AnimationClip>, IEvent<Self> { }

	/// <summary> Animation, that will be player when the chip will be casted </summary>
	[GameScope] public sealed class CastAnimation : ValueComponent<AnimationClip> { }

	[GameScope] public sealed class AnimationPrepared : FlagComponent { }

	[GameScope] public sealed class AnimationEnded : FlagComponent { }

	[GameScope] public sealed class CastSound : ValueComponent<Sound> { }

	[GameScope] public sealed class RepeatSound : ValueComponent<float> { }

	[GameScope] public sealed class TimeToNextRepeat : ValueComponent<float> { }
}