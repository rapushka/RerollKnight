using Entitas;
using Zenject;

namespace Code
{
	public sealed class SpawnWallsSystem : IInitializeSystem
	{
		private readonly GenerationConfig _generationConfig;
		private readonly RandomService _random;
		private readonly IRandomFieldAccess _field;
		private readonly WallsFactory _wallsFactory;

		[Inject]
		public SpawnWallsSystem
		(
			IRandomFieldAccess field,
			GenerationConfig generationConfig,
			RandomService random,
			WallsFactory wallsFactory
		)
		{
			_wallsFactory = wallsFactory;
			_field = field;
			_generationConfig = generationConfig;
			_random = random;
		}

		public void Initialize()
		{
			var count = _random.RangeInclusive(_generationConfig.WallsCount);

			for (var i = 0; i < count; i++)
				_wallsFactory.Create(_field.NextEmptyCell().GetCoordinates());
		}
	}
}