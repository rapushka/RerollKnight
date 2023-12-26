using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class PlayCastAnimationSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public PlayCastAnimationSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private Entity<GameScope> PickedChip   => Unique.GetEntity<PickedChip>();
		private Entity<GameScope> CurrentActor => Unique.GetEntity<CurrentActor>();

		private UniqueComponentsContainer<GameScope> Unique => _contexts.Get<GameScope>().Unique;

		public void Initialize()
		{
			var pickedChip = PickedChip;

			if (pickedChip.Has<CastAnimation>())
				CurrentActor.Replace<PlayAnimation, AnimationClip>(pickedChip.Get<CastAnimation>().Value);
		}
	}
}