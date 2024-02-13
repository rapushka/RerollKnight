using Zenject;

namespace Code
{
	public class CellsSpawner
	{
		private readonly GenerationConfig _generationConfig;
		private readonly CellsFactory _cellsFactory;

		[Inject]
		public CellsSpawner(GenerationConfig generationConfig, CellsFactory cellsFactory)
		{
			_generationConfig = generationConfig;
			_cellsFactory = cellsFactory;
		}

		public void SpawnCells()
		{
			var sizes = _generationConfig.RoomSizes;

			for (var x = 0; x < sizes.Column; x++)
			for (var y = 0; y < sizes.Row; y++)
			{
				_cellsFactory.Create(x, y);
			}
		}
	}
}