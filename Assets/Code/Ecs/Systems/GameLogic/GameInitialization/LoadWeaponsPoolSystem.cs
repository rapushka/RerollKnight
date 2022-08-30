using System.Collections.Generic;
using System.Linq;
using Code.Services.Interfaces;
using Code.Workflow.Extensions;
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
			=> _contexts.game.SetWeaponsPool(LoadEntities());

		private IEnumerable<GameEntity> LoadEntities()
			=> BalanceService.Weapons.Select(Load);

		private GameEntity Load(GameObject prefab)
			=> _contexts.game.CreateEntity()
			            .Do((e) => e.isWeapon = true)
			            .Do((e) => BindGameObject(prefab, e));

		private void BindGameObject(GameObject viewPrefab, GameEntity entity)
			=> entity.AddGameObject(LoadInactiveGameObject(viewPrefab, entity));

		private GameObject LoadInactiveGameObject(GameObject viewPrefab, IEntity entity)
			=> ViewsService.LoadViewForEntity(viewPrefab, entity)
			               .Do((o) => o.SetActive(false));
	}
}