using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Ecs.Systems.View
{
	public sealed class SetupWeaponViewSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public SetupWeaponViewSystem(Contexts contexts)
			: base(contexts.game)
		{
			_contexts = contexts;
		}

		private GameEntity Player => _contexts.game.playerEntity;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.Weapon);

		protected override bool Filter(GameEntity entity) => entity.hasTransform;

		protected override void Execute(List<GameEntity> entites) 
			=> entites.ForEach(Setup);

		private void Setup(GameEntity e)
		{
			SetPlayerAsParent(e);
			
			e.AddSpawnPosition(Vector3.zero);
		}

		private void SetPlayerAsParent(GameEntity weapon) 
			=> weapon.transform.Value.SetParent(Player.transform);
	}
}