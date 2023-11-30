using UnityEngine;
using GameEntityBeh = Entitas.Generic.EntityBehaviour<Code.GameScope>;

namespace Code
{
	public interface IResourcesService
	{
		GameEntityBeh PlayerPrefab { get; }
		GameEntityBeh CellPrefab   { get; }
		GameEntityBeh ChipPrefab   { get; }
		GameEntityBeh EnemyPrefab  { get; }
	}

	public class ResourcesService : IResourcesService
	{
		public GameEntityBeh PlayerPrefab => Resources.Load<GameEntityBeh>("Player/Prefab");
		public GameEntityBeh CellPrefab   => Resources.Load<GameEntityBeh>("Field/CellPrefab");
		public GameEntityBeh ChipPrefab   => Resources.Load<GameEntityBeh>("Chips/ChipPrefab");
		public GameEntityBeh EnemyPrefab  => Resources.Load<GameEntityBeh>("Enemy/Enemy");
	}
}