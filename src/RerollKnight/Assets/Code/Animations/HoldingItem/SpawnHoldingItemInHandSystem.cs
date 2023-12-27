using Code.Component;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class SpawnHoldingItemInHandSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public SpawnHoldingItemInHandSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private Entity<GameScope> PickedChip   => Unique.GetEntity<PickedChip>();
		private Entity<GameScope> CurrentActor => Unique.GetEntity<CurrentActor>();

		private UniqueComponentsContainer<GameScope> Unique => _contexts.Get<GameScope>().Unique;

		public void Initialize()
		{
			if (PickedChip.Has<HoldingItem>())
				CurrentActor.Replace<HoldingItem, GameObject>(PickedChip.Get<HoldingItem>().Value);
		}
	}
}