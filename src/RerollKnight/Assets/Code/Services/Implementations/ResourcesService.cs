using UnityEngine;

namespace Code
{
	public interface IResourcesService
	{
		GameEntityBehaviour PlayerPrefab { get; }
		GameEntityBehaviour CellPrefab   { get; }
		GameEntityBehaviour ChipPrefab   { get; }
	}

	public class ResourcesService : IResourcesService
	{
		public GameEntityBehaviour PlayerPrefab => Resources.Load<GameEntityBehaviour>("Player/Prefab");
		public GameEntityBehaviour CellPrefab   => Resources.Load<GameEntityBehaviour>("Field/CellPrefab");
		public GameEntityBehaviour ChipPrefab   => Resources.Load<GameEntityBehaviour>("Chips/ChipPrefab");
	}
}