using Entitas;
using Zenject;

namespace Code
{
	public sealed class SpawnActorsSystem : IInitializeSystem
	{
		private readonly ActorsFactory _actorsFactory;
		private readonly ChipsConfig _chipsConfig;
		private readonly IRandomFieldAccess _field;
		private readonly GenerationConfig _generationConfig;
		private readonly RandomService _random;

		[Inject]
		public SpawnActorsSystem
		(
			ActorsFactory actorsFactory,
			ChipsConfig chipsConfig,
			IRandomFieldAccess field,
			GenerationConfig generationConfig,
			RandomService random
		)
		{
			_actorsFactory = actorsFactory;
			_chipsConfig = chipsConfig;
			_field = field;
			_generationConfig = generationConfig;
			_random = random;
		}

		private Coordinates NextRandomCoordinates => _field.NextEmptyCell().GetCoordinates();

		public void Initialize()
		{
			SpawnPlayer();
			SpawnEnemies();
		}

		private void SpawnPlayer()
		{
			var zeroCoordinates = new Coordinates(0, 0, Coordinates.Layer.Default);
			_actorsFactory.CreatePlayer(zeroCoordinates, _chipsConfig.ChipsBehaviours);
		}

		private void SpawnEnemies()
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