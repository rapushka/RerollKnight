using Entitas;

namespace Code
{
	public sealed class SpawnFieldSystem : IInitializeSystem
	{
		// ReSharper disable once NotAccessedField.Local – keep the contexts for persist systems adding
		private Contexts _contexts;
		private const int FieldSizes = 3;

		public SpawnFieldSystem(Contexts contexts) => _contexts = contexts;

		private static GameEntityBehaviour CellPrefab => ServicesMediator.Resources.CellPrefab;

		public void Initialize()
		{
			for (var x = 0; x < FieldSizes; x++)
			{
				for (var y = 0; y < FieldSizes; y++)
				{
					var cell = ServicesMediator.Assets.SpawnBehaviour(CellPrefab);
					cell.Entity.AddCoordinatesUnderField(new Coordinates(x, y));
				}
			}
		}
	}
}