using System.Collections.Generic;
using Code.Services.Interfaces;
using Code.Workflow.Extensions;
using Entitas;

namespace Code.Ecs.Systems.Controls.Aiming
{
	public sealed class SetupAimingAtCursorSystem : ReactiveSystem<GameEntity>, IInitializeSystem
	{
		private readonly Contexts _contexts;
		private GameEntity _cursor;

		public SetupAimingAtCursorSystem(Contexts contexts)
			: base(contexts.game)
		{
			_contexts = contexts;
		}

		private GameContext GameContext => _contexts.game;
		private IIdentifierService<int> Identifier => _contexts.services.identifierService.Value;

		protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
			=> context.CreateCollector(GameMatcher.WeaponTransform);

		protected override bool Filter(GameEntity entity) => true;

		public void Initialize()
		{
			_cursor = GameContext.cursorEntity
			                     .Do((c) => c.AddId(Identifier.Next()))
			                     .Do((c) => c.AddLookAtObjectId(c.id));
		}

		protected override void Execute(List<GameEntity> entites)
			=> entites.ForEach(InitializeWeapon);

		private void InitializeWeapon(GameEntity weapon)
			=> weapon
			   		.Do((w) => w.AddTransform(weapon.weaponTransform))
			   		.Do((w) => w.AddLookAtSubjectId(_cursor.id));
	}
}