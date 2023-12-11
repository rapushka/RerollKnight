using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public class RoomFactory
	{
		private readonly GenerationConfig _generationConfig;
		private readonly IAssetsService _assets;
		private readonly IResourcesService _resources;
		private readonly IHoldersProvider _holdersProvider;
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<GameScope>> _roomResidents;
		private readonly ActorsFactory _actorsFactory;
		private readonly ChipsConfig _chipsConfig;
		private readonly RandomService _random;
		private readonly IRandomFieldAccess _field;
		private readonly WallsFactory _wallsFactory;

		[Inject]
		public RoomFactory
		(
			Contexts contexts,
			GenerationConfig generationConfig,
			IAssetsService assets,
			IResourcesService resources,
			IHoldersProvider holdersProvider,
			ActorsFactory actorsFactory,
			ChipsConfig chipsConfig,
			RandomService random,
			IRandomFieldAccess field,
			WallsFactory wallsFactory
		)
		{
			_contexts = contexts;
			_generationConfig = generationConfig;
			_assets = assets;
			_resources = resources;
			_holdersProvider = holdersProvider;
			_actorsFactory = actorsFactory;
			_chipsConfig = chipsConfig;
			_random = random;
			_field = field;
			_wallsFactory = wallsFactory;

			_roomResidents = _contexts.GetGroup(AllOf(Get<RoomResident>()).NoneOf(Get<ForeignID>()));
		}

		private Coordinates NextRandomCoordinates => _field.NextEmptyCell().GetCoordinates();

		public void Create(Coordinates coordinates)
		{
			SpawnCells();
			SpawnPlayer();
			SpawnEnemies();
			SpawnWalls();
			// Add<SpawnWallsSystem>();

			var entity = BindToRoom(coordinates);
			entity.Is<Disabled>(true);
		}

		private void SpawnCells()
		{
			if (_contexts.GetGroup(Get<Cell>()).Any()) // TODO: 🔥костыль🔥
				return;

			var sizes = _generationConfig.RoomSizes;
			for (var x = 0; x < sizes.Column; x++)
			for (var y = 0; y < sizes.Row; y++)
			{
				_assets.SpawnBehaviour(_resources.CellPrefab, _holdersProvider.CellsHolder.transform).Entity
					.Add<Component.Coordinates, Coordinates>(new Coordinates(x, y, Coordinates.Layer.Bellow))
					.Is<Empty>(true)
					;
			}
		}

		private void SpawnPlayer()
		{
			if (_contexts.GetGroup(Get<Player>()).Any()) // TODO: 🔥костыль🔥
				return;

			var zeroCoordinates = new Coordinates(0, 0, Coordinates.Layer.Default);
			_actorsFactory.CreatePlayer(zeroCoordinates, _chipsConfig.ChipsBehaviours);
		}

		private void SpawnEnemies()
		{
			var enemiesCount = _random.RangeInclusive(_generationConfig.EnemiesCount);
			for (var i = 0; i < enemiesCount; i++)
			{
				var coordinates = NextRandomCoordinates.WithLayer(Coordinates.Layer.Default);
				var enemy = _actorsFactory.CreateEnemy(coordinates, _chipsConfig.ChipsBehaviours);
				enemy.Add<CashedLayer, Coordinates.Layer>(coordinates.OnLayer); // TODO: 🔥костыль🔥
				enemy.Replace<Component.Coordinates, Coordinates>(coordinates.WithLayer(Coordinates.Layer.None)); // TODO: 🔥костыль🔥
			}
		}

		private void SpawnWalls()
		{
			var count = _random.RangeInclusive(_generationConfig.WallsCount);

			for (var i = 0; i < count; i++)
			{
				var coordinates = NextRandomCoordinates.WithLayer(Coordinates.Layer.Default);
				var wall = _wallsFactory.Create(coordinates);
				wall.Add<CashedLayer, Coordinates.Layer>(coordinates.OnLayer); // TODO: 🔥костыль🔥
				wall.Replace<Component.Coordinates, Coordinates>(coordinates.WithLayer(Coordinates.Layer.None)); // TODO: 🔥костыль🔥
			}
		}

		private Entity<GameScope> BindToRoom(Coordinates coordinates)
		{
			var roomEntity = _contexts.Get<GameScope>().CreateEntity().Identify();
			roomEntity.Add<DebugName, string>("Room");
			roomEntity.Add<Component.Coordinates, Coordinates>(coordinates);

			foreach (var e in _roomResidents.GetEntities())
				e.Add<ForeignID, string>(roomEntity.EnsureID());

			return roomEntity;
		}
	}
}