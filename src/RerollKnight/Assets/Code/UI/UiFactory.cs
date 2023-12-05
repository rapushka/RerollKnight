using System;
using Code.Component;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class UiFactory
	{
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly IHoldersProvider _holders;

		[Inject]
		public UiFactory(IAssetsService assets, IResourcesService resources, IHoldersProvider holders)
		{
			_holders = holders;
			_resources = resources;
			_assets = assets;
		}

		public Entity<GameScope> CreateHealthBar(Entity<GameScope> actor)
		{
			return actor.Is<Enemy>() ? CreateEnemyHealthBar(actor)
				: actor.Is<Player>() ? CreatePlayerHealthBar(actor)
				                       : throw new InvalidOperationException("Unknown actor");
		}

		private Entity<GameScope> CreateEnemyHealthBar(Entity<GameScope> actor)
			=> Create(actor, _resources.EnemyHealthBar, actor.Get<ViewTransform>().Value);

		private Entity<GameScope> CreatePlayerHealthBar(Entity<GameScope> actor)
			=> Create(actor, _resources.PlayerHealthBar, _holders.HudHolder);

		private Entity<GameScope> Create(Entity<GameScope> actor, EntityBehaviour<GameScope> prefab, Transform parent)
		{
			var viewBehaviour = _assets.SpawnBehaviour(prefab, parent);
			var view = viewBehaviour.Entity
			                        .Add<ForeignID, string>(actor.Get<ID>().Value)
				;

			actor.Register(viewBehaviour.GetComponent<HealthBarView>());

			return view;
		}
	}
}