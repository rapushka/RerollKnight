using System.Collections.Generic;
using System.Linq;
using Code.Services.Interfaces;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.GameLogic.GameInitialization
{
	public sealed class LoadWeaponsPoolSystem : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public LoadWeaponsPoolSystem(Contexts contexts) => _contexts = contexts;

		private IResourcesService BalanceService => _contexts.services.resourcesService.Value;
		private IViewsService ViewsService => _contexts.services.viewService.Value;

		public void Initialize()
		{
			_contexts.game.SetWeaponsPool(LoadEntities());
		}

		private IEnumerable<GameEntity> LoadEntities() 
			=> BalanceService.Weapons.Select(Load);

		private GameEntity Load(GameObject prefab)
		{
			GameEntity newWeapon = _contexts.game.CreateEntity();
			newWeapon.isWeapon = true;
			
			GameObject weaponObject = ViewsService.LoadViewForEntity(prefab, newWeapon);
			weaponObject.SetActive(false);
			newWeapon.AddGameObject(weaponObject);
			
			return newWeapon;
		}
	}
}