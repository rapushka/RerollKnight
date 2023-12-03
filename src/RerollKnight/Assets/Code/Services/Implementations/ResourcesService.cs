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
	}

	public class ResourcesService : IResourcesService
	{
		public GameEntityView PlayerPrefab     => Resources.Load<GameEntityView>("Player/Prefab");
		public GameEntityView CellPrefab       => Resources.Load<GameEntityView>("Field/CellPrefab");
		public GameEntityView ChipPrefab       => Resources.Load<GameEntityView>("Chips/ChipPrefab");
		public GameEntityView EnemyPrefab      => Resources.Load<GameEntityView>("Enemy/Enemy");
		public GameEntityView CurrentActorText => Resources.Load<GameEntityView>("UI/Views/Current Actor Text");
		public GameEntityView PlayerHealthBar  => Resources.Load<GameEntityView>("UI/Views/Player Health");
		public GameEntityView EnemyHealthBar   => Resources.Load<GameEntityView>("UI/Views/Enemy Health");
	}
}