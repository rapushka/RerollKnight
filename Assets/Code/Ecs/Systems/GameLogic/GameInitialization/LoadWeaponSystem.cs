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
			GameEntity weapon = _contexts.game.CreateEntity();
			weapon.isWeapon = true;

			Player.AddCurrentWeapon(weapon);
		}
	}
}