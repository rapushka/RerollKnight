using System;
using Code.Component;
using Entitas.Generic;

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
		{
			if (actor.Is<Enemy>())
				return null; // throw new NotImplementedException();

			if (actor.Is<Player>())
				return CreatePlayerHealthBar(actor);

			throw new InvalidOperationException("Unknown actor");
		}

		private Entity<GameScope> CreatePlayerHealthBar(Entity<GameScope> actor)
		{
			var healthBar = _assets.SpawnBehaviour(_resources.PlayerHealthBar, _holders.HudHolder).Entity;
			healthBar.Add<BelongToActor, int>(actor.Get<ID>().Value);
			return healthBar;
		}
	}
}