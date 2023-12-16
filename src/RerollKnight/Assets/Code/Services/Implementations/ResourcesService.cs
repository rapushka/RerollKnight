using UnityEngine;
using GameEntityView = Entitas.Generic.EntityBehaviour<Code.GameScope>;

namespace Code
{
	public interface IResourcesService
	{
		GameEntityView PlayerPrefab     { get; }
		GameEntityView CellPrefab       { get; }
		GameEntityView ChipPrefab       { get; }
		GameEntityView EnemyPrefab      { get; }
		GameEntityView CurrentActorText { get; }
		GameEntityView PlayerHealthBar  { get; }
		GameEntityView EnemyHealthBar   { get; }
		GameEntityView WallPrefab       { get; }
		GameEntityView DoorPrefab       { get; }

		GameObject CanvasPrefab { get; }
	}

	public class ResourcesService : IResourcesService
	{
		public GameEntityView PlayerPrefab     => Resources.Load<GameEntityView>("Actors/Player/Player");
		public GameEntityView CellPrefab       => Resources.Load<GameEntityView>("Field/CellPrefab");
		public GameEntityView ChipPrefab       => Resources.Load<GameEntityView>("Chips/Chip View Prefab");
		public GameEntityView EnemyPrefab      => Resources.Load<GameEntityView>("Actors/Enemy/Enemy");
		public GameEntityView CurrentActorText => Resources.Load<GameEntityView>("Actors/Current Actor Text");
		public GameEntityView PlayerHealthBar  => Resources.Load<GameEntityView>("Actors/Player/Player Health");
		public GameEntityView EnemyHealthBar   => Resources.Load<GameEntityView>("Actors/Enemy/Enemy Health");
		public GameEntityView WallPrefab       => Resources.Load<GameEntityView>("Field/Wall Prefab");
		public GameEntityView DoorPrefab       => Resources.Load<GameEntityView>("Field/Door");

		public GameObject CanvasPrefab => Resources.Load<GameObject>("UI/Canvas");
	}
}