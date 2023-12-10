using Code.Component;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class WallsFactory
	{
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly IHoldersProvider _holdersProvider;

		[Inject]
		public WallsFactory
		(
			IAssetsService assets,
			IResourcesService resources,
			IHoldersProvider holdersProvider
		)
		{
			_assets = assets;
			_resources = resources;
			_holdersProvider = holdersProvider;
		}

		public Entity<GameScope> Create(Coordinates coordinates)
			=> _assets.SpawnBehaviour(_resources.WallPrefab, _holdersProvider.CellsHolder.transform).Entity
			          .Add<Component.Coordinates, Coordinates>(coordinates)
			          .Is<RoomResident>(true)
			          .Identify();
	}
}