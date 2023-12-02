using Entitas;
using Zenject;

namespace Code
{
	public sealed class SpawnActorsSystem : IInitializeSystem
	{
		private readonly ActorsFactory _actorsFactory;

		[Inject]
		public SpawnActorsSystem(ActorsFactory actorsFactory)
			=> _actorsFactory = actorsFactory;

		public void Initialize()
		{
			_actorsFactory.CreatePlayer(new Coordinates(0, 0));
			_actorsFactory.CreateEnemy(new Coordinates(3, 3));
		}
	}
}