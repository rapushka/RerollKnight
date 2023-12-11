namespace Code
{
	public class WallsSpawner
	{
		private readonly RandomService _random;
		private readonly IRandomFieldAccess _field;
		private readonly GenerationConfig _generationConfig;
		private readonly WallsFactory _wallsFactory;

		public WallsSpawner
		(
			RandomService random,
			IRandomFieldAccess field,
			GenerationConfig generationConfig,
			WallsFactory wallsFactory
		)
		{
			_random = random;
			_field = field;
			_generationConfig = generationConfig;
			_wallsFactory = wallsFactory;
		}

		private Coordinates NextRandomCoordinates => _field.NextEmptyCell().GetCoordinates();

		public void SpawnWalls()
		{
			var count = _random.RangeInclusive(_generationConfig.WallsCount);

			for (var i = 0; i < count; i++)
				_wallsFactory.Create(NextRandomCoordinates.WithLayer(Coordinates.Layer.Default));
		}
	}
}