using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class SpawnEnemySystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public SpawnEnemySystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize() { }
	}
}