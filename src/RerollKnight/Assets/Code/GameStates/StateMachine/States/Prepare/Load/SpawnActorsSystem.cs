using Entitas;
using Zenject;

namespace Code
{
	public sealed class SpawnActorsSystem : IInitializeSystem
	{
		private readonly ActorsFactory _actorsFactory;
		private readonly ChipsConfig _chipsConfig;

		[Inject]
		public SpawnActorsSystem(ActorsFactory actorsFactory, ChipsConfig chipsConfig)
		{
			_actorsFactory = actorsFactory;
			_chipsConfig = chipsConfig;
		}

		public void Initialize()
		{
			_actorsFactory.CreatePlayer(new Coordinates(0, 0), _chipsConfig.Chips);
			_actorsFactory.CreateEnemy(new Coordinates(3, 3));
		}
	}
}