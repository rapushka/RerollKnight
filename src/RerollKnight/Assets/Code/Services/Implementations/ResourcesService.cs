using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public interface IResourcesService
	{
		EntityBehaviour<GameScope> PlayerPrefab { get; }
		EntityBehaviour<GameScope> CellPrefab   { get; }
		EntityBehaviour<GameScope> ChipPrefab   { get; }
	}

	public class ResourcesService : IResourcesService
	{
		public EntityBehaviour<GameScope> PlayerPrefab => Resources.Load<EntityBehaviour<GameScope>>("Player/Prefab");
		public EntityBehaviour<GameScope> CellPrefab => Resources.Load<EntityBehaviour<GameScope>>("Field/CellPrefab");
		public EntityBehaviour<GameScope> ChipPrefab => Resources.Load<EntityBehaviour<GameScope>>("Chips/ChipPrefab");
	}
}