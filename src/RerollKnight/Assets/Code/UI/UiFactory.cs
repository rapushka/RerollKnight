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
		private readonly Contexts _contexts;

		[Inject]
		public UiFactory
			(IAssetsService assets, IResourcesService resources, IHoldersProvider holders, Contexts contexts)
		{
			_holders = holders;
			_resources = resources;
			_assets = assets;
			_contexts = contexts;
		}

		private Entity<GameScope> Camera => _contexts.Get<GameScope>().Unique.GetEntity<Component.Camera>();

		public Entity<GameScope> CreateHealthBar(Entity<GameScope> actor)
		{
			return actor.Is<Enemy>() ? CreateEnemyHealthBar(actor)
				: actor.Is<Player>() ? Create(actor, _resources.PlayerHealthBar, _holders.HudHolder)
				                       : throw new InvalidOperationException("Unknown actor");
		}

		private Entity<GameScope> Create(Entity<GameScope> actor, EntityBehaviour<GameScope> prefab, Transform parent)
		{
			var viewBehaviour = _assets.SpawnBehaviour(prefab, parent);
			var view = viewBehaviour.Entity
			                        .Add<BelongToActor, int>(actor.Get<ID>().Value);

			actor.Register(viewBehaviour.GetComponent<HealthBarView>());

			return view;
		}

		private Entity<GameScope> CreateEnemyHealthBar(Entity<GameScope> actor)
		{
			var healthBar = Create(actor, _resources.EnemyHealthBar, actor.Get<ViewTransform>().Value);
			healthBar.Add<LookAt, Entity<GameScope>>(Camera);
			return healthBar;
		}
	}
}