using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Code.Coordinates.Layer;
using static Entitas.Generic.ScopeMatcher<Code.GameScope>;

namespace Code
{
	public sealed class GenerateLevelSystem : ReadyOnConditionSystemBase, IExecuteSystem
	{
		private readonly RoomFactory _roomFactory;
		private readonly Coordinates _lastCoordinates;
		private readonly CellsSpawner _cellsSpawner;
		private readonly ActorsSpawner _actorsSpawner;
		private readonly WallsSpawner _wallsSpawner;
		private readonly IGroup<Entity<GameScope>> _roomResidents;

		private Coordinates _currentCoordinates;
		private Entity<GameScope> _player;

		[Inject]
		public GenerateLevelSystem
		(
			Contexts contexts,
			RoomFactory roomFactory,
			GenerationConfig generationConfig,
			CellsSpawner cellsSpawner,
			ActorsSpawner actorsSpawner,
			WallsSpawner wallsSpawner
		)
			: base(contexts)
		{
			_roomFactory = roomFactory;
			_cellsSpawner = cellsSpawner;
			_actorsSpawner = actorsSpawner;
			_wallsSpawner = wallsSpawner;

			_roomResidents = contexts.GetGroup(AllOf(Get<RoomResident>()).NoneOf(Get<ForeignID>()));
			_lastCoordinates = generationConfig.LevelSizes.Add(column: -1, row: -1).WithLayer(Ignore);
		}

		public override void Initialize()
		{
			base.Initialize();

			_currentCoordinates = Coordinates.Zero.WithLayer(Coordinates.Layer.Room);

			_cellsSpawner.SpawnCells();
			_player = _actorsSpawner.SpawnPlayer();

			_player.ReplaceCoordinates(_player.GetCoordinates(withLayer: None));
		}

		public void Execute()
		{
			if (Ready)
				return;

			var roomEntity = _roomFactory.Create(_currentCoordinates);

			_wallsSpawner.SpawnWalls(roomEntity);
			_actorsSpawner.SpawnEnemies();

			BindResidentsToRoom(roomEntity);
			roomEntity.Is<Disabled>(true);

			if (_currentCoordinates == _lastCoordinates)
			{
				Ready = true;
				return;
			}

			_currentCoordinates = NextCoordinates();
		}

		public override void TearDown()
		{
			base.TearDown();

			_player.ReplaceCoordinates(_player.GetCoordinates(withLayer: Default));
		}

		private Coordinates NextCoordinates()
			=> _currentCoordinates.Column < _lastCoordinates.Column
				? _currentCoordinates.Add(column: 1)
				: _currentCoordinates.WithColumn(0).Add(row: 1);

		private void BindResidentsToRoom(Entity<GameScope> roomEntity)
		{
			foreach (var e in _roomResidents.GetEntities())
				e.Add<ForeignID, string>(roomEntity.EnsureID());
		}
	}
}