using Zenject;

namespace Code
{
	public class LevelFactory
	{
		private readonly RoomFactory _roomFactory;
		private readonly GenerationConfig _generationConfig;

		[Inject]
		public LevelFactory(RoomFactory roomFactory, GenerationConfig generationConfig)
		{
			_roomFactory = roomFactory;
			_generationConfig = generationConfig;
		}

		public void Create()
		{
			var sizes = _generationConfig.LevelSizes;

			for (var x = 0; x < sizes.Column; x++)
			for (var y = 0; y < sizes.Row; y++)
			{
				_roomFactory.Create(new Coordinates(x, y, Coordinates.Layer.Room));
			}
		}
	}
}