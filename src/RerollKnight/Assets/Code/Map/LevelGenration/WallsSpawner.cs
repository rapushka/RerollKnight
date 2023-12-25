using System.Linq;
using Entitas.Generic;
using static Code.Coordinates.Layer;

namespace Code
{
	public class WallsSpawner
	{
		private readonly GenerationConfig _generationConfig;
		private readonly WallsFactory _wallsFactory;

		public WallsSpawner(GenerationConfig generationConfig, WallsFactory wallsFactory)
		{
			_generationConfig = generationConfig;
			_wallsFactory = wallsFactory;
		}

		public void SpawnWalls(Entity<GameScope> roomEntity)
		{
			var wallsLayout = IsFirstRoom(roomEntity)
				? _generationConfig.WallLayouts.Where((rl) => rl.CanBeFirst).PickRandom()
				: _generationConfig.WallLayouts.PickRandom();

			var sizes = _generationConfig.RoomSizes;

			for (var column = 0; column < sizes.Column; column++)
			for (var row = 0; row < sizes.Row; row++)
			{
				if (wallsLayout.Walls[column, row])
					_wallsFactory.Create(new Coordinates(column, row, Default));
			}
		}

		private static bool IsFirstRoom(Entity<GameScope> roomEntity)
			=> roomEntity.GetCoordinates() == Coordinates.Zero.WithLayer(Room);
	}
}