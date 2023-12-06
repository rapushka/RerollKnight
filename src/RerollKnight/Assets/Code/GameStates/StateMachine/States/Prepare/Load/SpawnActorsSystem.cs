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

		[Inject]
		public SpawnActorsSystem(ActorsFactory actorsFactory, ChipsConfig chipsConfig, IRandomFieldAccess field)
		{
			_actorsFactory = actorsFactory;
			_chipsConfig = chipsConfig;
			_field = field;
		}

		private Coordinates CoordinatesOfNextEmptyCell => _field.NextEmptyCell().Get<CoordinatesUnderField>().Value;

		public void Initialize()
		{
			_actorsFactory.CreatePlayer(new Coordinates(0, 0), _chipsConfig.Chips);
			_actorsFactory.CreateEnemy(CoordinatesOfNextEmptyCell, _chipsConfig.Chips);
			_actorsFactory.CreateEnemy(CoordinatesOfNextEmptyCell, _chipsConfig.Chips);
		}
	}
}