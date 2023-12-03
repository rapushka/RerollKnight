using System;
using Code.Component;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class UiFactory
	{
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly IHoldersProvider _holders;

		public UiFactory(IAssetsService assets, IResourcesService resources, IHoldersProvider holders)
		{
			_holders = holders;
			_resources = resources;
			_assets = assets;
		}

		public Entity<GameScope> CreateHealthBar(Entity<GameScope> actor)
			=> actor.Is<Enemy>()     ? Create(actor, _resources.EnemyHealthBar, actor.Get<RootTransform>().Value)
				: actor.Is<Player>() ? Create(actor, _resources.PlayerHealthBar, _holders.HudHolder)
				                       : throw new InvalidOperationException("Unknown actor");

		private Entity<GameScope> Create(Entity<GameScope> actor, EntityBehaviour<GameScope> prefab, Transform parent)
			=> _assets.SpawnBehaviour(prefab, parent).Entity
			          .Add<BelongToActor, int>(actor.Get<ID>().Value);
	}
}