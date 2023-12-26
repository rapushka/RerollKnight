using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class HoldingItemView : BaseListener<GameScope, HoldingItem>
	{
		[SerializeField] private Transform _handTransform;

		private GameObject _item;

		public override void OnValueChanged(Entity<GameScope> entity, HoldingItem component)
		{
			if (entity.Has<HoldingItem>())
				SpawnPrefab(entity.Get<HoldingItem>().Value);
			else
				DestroyItem();
		}

		private void SpawnPrefab(GameObject prefab)
			=> _item = Instantiate(prefab, _handTransform);

		private void DestroyItem()
			=> Destroy(_item);
	}
}