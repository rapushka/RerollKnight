using Entitas;
using Zenject;

namespace Code
{
	public sealed class SpawnDoorsSystem : IInitializeSystem
	{
		private readonly DoorsSpawner _doorsSpawner;

		[Inject]
		public SpawnDoorsSystem(DoorsSpawner doorsSpawner)
			=> _doorsSpawner = doorsSpawner;

		public void Initialize()
			=> _doorsSpawner.Spawn();
	}
}