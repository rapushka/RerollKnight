using Code.Workflow.Extensions;
using Entitas;

namespace Code.Ecs.Systems.GameLogic.GameInitialization
{
	public sealed class LoadWeaponSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public LoadWeaponSystem(Contexts contexts)
		{
			_contexts = contexts;
		}

		private GameEntity Player => _contexts.game.playerEntity;

		public void Initialize()
		{
			GameEntity randomWeapon = _contexts.game.weaponsPool.Value.PickRandom();
			randomWeapon.gameObject.Value.SetActive(true);
			
			Player.AddCurrentWeapon(randomWeapon);
		}
	}
}