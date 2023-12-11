namespace Code
{
	public class ActorsSpawner
	{
		private readonly ActorsFactory _actorsFactory;
		private readonly ChipsConfig _chipsConfig;
		private readonly RandomService _random;
		private readonly IRandomFieldAccess _field;
		private readonly GenerationConfig _generationConfig;

		public ActorsSpawner
		(
			ActorsFactory actorsFactory,
			ChipsConfig chipsConfig,
			RandomService random,
			IRandomFieldAccess field,
			GenerationConfig generationConfig
		)
		{
			_actorsFactory = actorsFactory;
			_chipsConfig = chipsConfig;
			_random = random;
			_field = field;
			_generationConfig = generationConfig;
		}

		private Coordinates NextRandomCoordinates => _field.NextEmptyCell().GetCoordinates();

		public void SpawnPlayer()
		{
			var zeroCoordinates = Coordinates.Zero.WithLayer(Coordinates.Layer.Default);
			_actorsFactory.CreatePlayer(zeroCoordinates, _chipsConfig.ChipsBehaviours);
		}

		public void SpawnEnemies()
		{
			var enemiesCount = _random.RangeInclusive(_generationConfig.EnemiesCount);
			for (var i = 0; i < enemiesCount; i++)
			{
				var coordinates = NextRandomCoordinates.WithLayer(Coordinates.Layer.Default);
				_actorsFactory.CreateEnemy(coordinates, _chipsConfig.ChipsBehaviours);
			}
		}
	}
}