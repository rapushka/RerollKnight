using Entitas;
using UnityEngine;

namespace Code
{
	public sealed class SpawnFieldSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public SpawnFieldSystem(Contexts contexts) => _contexts = contexts;

		private static GameEntityBehaviour CellPrefab => ServicesMediator.Resources.CellPrefab;

		public void Initialize()
		{
			for (var x = -1; x <= 1; x++)
			{
				for (var y = -1; y <= 1; y++)
				{
					var cell = SpawnCellAt(x, y);
				}
			}
		}

		private static GameEntityBehaviour SpawnCellAt(int x, int y)
			=> ServicesMediator.Assets.SpawnBehaviour(CellPrefab, new Vector2(x, y).ToTopDown());
	}
}