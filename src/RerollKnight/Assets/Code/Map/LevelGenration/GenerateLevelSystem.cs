using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class GenerateLevelSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly LevelFactory _levelFactory;

		[Inject]
		public GenerateLevelSystem(Contexts contexts, LevelFactory levelFactory)
		{
			_contexts = contexts;
			_levelFactory = levelFactory;
		}

		public void Initialize()
		{
			_levelFactory.Create();
			// Add<SpawnFieldSystem>();
			// Add<SpawnActorsSystem>();
			// Add<SpawnWallsSystem>();
		}
	}
}