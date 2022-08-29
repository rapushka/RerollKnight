using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.GameLogic.GameInitialization
{
	public sealed class SpawnPlayerSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public SpawnPlayerSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			GameEntity player = _contexts.game.CreateEntity();
			player.isPlayer = true;
			player.isWeighty = true;
			player.isInputReceiver = true;
			
			player.AddPosition(Vector3.zero);
		}
	}
}
