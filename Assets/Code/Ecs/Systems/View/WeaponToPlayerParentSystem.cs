using System.Collections.Generic;
using Entitas;

namespace Code.Ecs.Systems.View
{
	public sealed class WeaponToPlayerParentSystem : ReactiveSystem<GameEntity>
	{
		private readonly Contexts _contexts;

		public WeaponToPlayerParentSystem(Contexts contexts)
			: base(contexts.game)
		{
			_contexts = contexts;
		}

		private GameEntity Player => _contexts.game.playerEntity;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.WeaponTransform);

		protected override bool Filter(GameEntity entity)
			=> true;

		protected override void Execute(List<GameEntity> entites) 
			=> entites.ForEach(SetPlayerAsParent);

		private void SetPlayerAsParent(GameEntity weapon) 
			=> weapon.weaponTransform.Value.SetParent(Player.transform);
	}
}