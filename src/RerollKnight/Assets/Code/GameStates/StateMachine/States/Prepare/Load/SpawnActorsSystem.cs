using Code.Component;
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

		private Coordinates CoordinatesOfNextEmptyCell => _field.NextEmptyCell().Get<CoordinatesUnderField>().Value;

		public void Initialize()
		{
			_actorsFactory.CreatePlayer(new Coordinates(0, 0), _chipsConfig.Chips);

			SpawnEnemies();
		}

		private void SpawnEnemies()
		{
			var enemiesCount = _random.RangeInclusive(_generationConfig.EnemiesCount);
			for (var i = 0; i < enemiesCount; i++)
				_actorsFactory.CreateEnemy(CoordinatesOfNextEmptyCell, _chipsConfig.Chips);
		}
	}
}