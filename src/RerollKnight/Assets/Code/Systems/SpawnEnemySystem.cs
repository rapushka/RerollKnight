using Entitas;

namespace Code
{
	public sealed class SpawnEnemySystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public SpawnEnemySystem(Contexts contexts) => _contexts = contexts;

		public void Initialize()
		{
			var entity = _contexts.game.CreateEntity();

			entity.isEnemy = true;
			entity.AddHealth(100);
			entity.AddSome("abc");
		}
	}
}